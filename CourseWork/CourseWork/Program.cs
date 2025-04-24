using System.Net;
using System.Net.Sockets;

class DnsSpoofingSimulator
{
    static void Main()
    {
        UdpClient udpServer = new UdpClient(53);
        Console.WriteLine("DNS Spoofing Simulator is running...");

        while (true)
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] request = udpServer.Receive(ref remoteEP);
            string domain = ExtractDomainName(request);

            Console.WriteLine($"Sorğu alındı: {domain} -> 6.6.6.6");

            byte[] response = BuildSpoofedResponse(request, "6.6.6.6");
            udpServer.Send(response, response.Length, remoteEP);
        }
    }

    static string ExtractDomainName(byte[] request)
    {
        int position = 12; // DNS başlıqdan sonra domain hissəsi başlayır
        string domain = "";

        while (request[position] != 0)
        {
            int len = request[position++];
            for (int i = 0; i < len; i++)
            {
                domain += (char)request[position++];
            }
            domain += ".";
        }

        return domain.TrimEnd('.');
    }

    static byte[] BuildSpoofedResponse(byte[] request, string fakeIp)
    {
        byte[] response = new byte[request.Length + 16];
        Array.Copy(request, response, request.Length);

        // Header flags: QR=1 (response), OPCODE=0, AA=1, TC=0, RD=1, RA=1
        response[2] = 0x81;
        response[3] = 0x80;

        // Answer count = 1
        response[7] = 0x01;

        int pos = request.Length;

        // Name pointer to question section (offset 12)
        response[pos++] = 0xC0;
        response[pos++] = 0x0C;

        // Type A
        response[pos++] = 0x00; response[pos++] = 0x01;

        // Class IN
        response[pos++] = 0x00; response[pos++] = 0x01;

        // TTL (60 seconds)
        response[pos++] = 0x00; response[pos++] = 0x00;
        response[pos++] = 0x00; response[pos++] = 0x3C;

        // Data length: 4 bytes (IPv4)
        response[pos++] = 0x00; response[pos++] = 0x04;

        // IP address
        string[] ipParts = fakeIp.Split('.');
        foreach (string part in ipParts)
        {
            response[pos++] = byte.Parse(part);
        }

        return response;
    }
}
