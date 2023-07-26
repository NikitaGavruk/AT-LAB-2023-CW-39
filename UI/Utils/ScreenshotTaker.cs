using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Logger;

namespace UI.Utils
{
    public class ScreenshotTaker
    {
        public static string TakeScreenShot(Core.Logger.ExtentReporter.Projects project)
        {
            string saveDirectory;
            if (Environment.CurrentDirectory.EndsWith(@"bin\Debug"))
                saveDirectory = @"Screenshots";
            else
                saveDirectory = $@"{project}\bin\Dubug\Screenshots";

            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            else
            {
                try
                {
                    DeleteRepeatedFiles(saveDirectory, TestContext.CurrentContext.Test.Name, 5);
                }
                catch (Exception exe)
                {
                    logger.Error("Old Screenshots Were Not Deleted", exe.Message);
                }
            }

            string path = String.Format(saveDirectory + @"\{0}_{1}.{2}",
                    DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"),
                    TestContext.CurrentContext.Test.Name,
                    ImageFormat.Jpeg.ToString().ToLower());

            try
            {
                Screenshot screen = ((ITakesScreenshot)GetDriver()).GetScreenshot();
                byte[] array = screen.AsByteArray;

                using (Image image = Image.FromStream(new MemoryStream(array, false)))
                {
                    image.Save(path);
                }
            }
            catch (Exception exe)
            {
                logger.Error("Screenshot Was Not Taken", exe.Message);
                throw new LoggerException("Screenshot Was Not Taken");
            }
            return path;
        }
    }
}
