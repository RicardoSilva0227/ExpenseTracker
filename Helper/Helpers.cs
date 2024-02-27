
namespace ExpenseTracker.Helper
{
    public class Helpers
    {
        public void importFile(IFormFile file)
        {
            FileStream fs = null;
            try
            {
                int bufferSize = 1024 * 1024;
                using (FileStream fileStream = new FileStream("D:\\ExpenseTracker\\" +  file.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fs = new FileStream("C:\\Users\\ricar\\Downloads\\" + file.FileName, FileMode.Open, FileAccess.ReadWrite);
                    fileStream.SetLength(fs.Length);
                    int bytesRead = -1;
                    byte[] bytes = new byte[bufferSize];

                    while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                    {
                        fileStream.Write(bytes, 0, bytesRead);
                    }
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }
    }
}
