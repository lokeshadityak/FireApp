namespace FireApp.Services
{
    public class ServiceManagement : IServiceManagement
    {
        public void GenerateMerchendise()
        {
            Console.WriteLine($"Every 4 Min : GenerateMerchendise() {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void sendEmail()
        {
            Console.WriteLine($"Every 1 Min : sendEmail() {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void SyncData()
        {
            Console.WriteLine($"Every 2 Min : SyncData() {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        public void UpdateDatabase()
        {
            Console.WriteLine($"Every 3 Min  : UpdateDatabase() {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
