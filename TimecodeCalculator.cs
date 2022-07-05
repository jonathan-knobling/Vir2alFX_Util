namespace Vir2alFX_Util;

public static class TimecodeCalculator
{
    public static void CalculateTimecode()
    {
        while (true)
        {
            Console.Clear();
            
            int framecount = GetFrameCount();
            if (framecount == -1) return;
            
            int framerate = GetFrameRate();
            if (framerate == -1) return;

            int hours = framecount / framerate / 60 / 60;
            int minutes = framecount / framerate / 60 % 60;
            int seconds = framecount / framerate % 60;
            int frames = framecount % framerate;

            string h = hours < 10 ? "0" + hours : hours.ToString();
            string m = minutes < 10 ? "0" + minutes : minutes.ToString();
            string s = seconds < 10 ? "0" + seconds : seconds.ToString();
            string f = frames < 10 ? "0" + frames : frames.ToString();

            Console.WriteLine($"{h}:{m}:{s}:{f}");

            Console.ReadLine();
        }
    }

    internal static void CaclulateFrames()
    {
        Console.WriteLine("InputTimecode with : as seperator");
        String input = Console.ReadLine();
        string[] frames = input.Split(':');
        int hours = int.Parse(frames[0]);
        int minutes = int.Parse(frames[1]);
        int seconds = int.Parse(frames[2]);
        int frame = int.Parse(frames[3]);

        int totalFrameCount = frame + seconds * 24 + minutes * 24 * 60 + hours * 24 * 60 * 60;

        Console.WriteLine(totalFrameCount);
        Console.ReadLine();
    }

    private static int GetFrameRate()
    {
        string input = string.Empty;

        int curserLine = Console.GetCursorPosition().Top;
        
        while (input is not "exit")
        {
            //Clear Line
            Console.SetCursorPosition(0,curserLine);
            Console.Write("");
            
            Console.Write("Input Framerate: ");
            input = Console.ReadLine() ?? String.Empty;
            if (int.TryParse(input, out int framerate) && framerate > 0) return framerate;
        }
        
        return -1;
    }

    private static int GetFrameCount()
    {
        string input = string.Empty;
        
        int curserLine = Console.GetCursorPosition().Top;
        
        while (input is not "exit")
        {
            //Clear Line
            Console.SetCursorPosition(0,curserLine);
            Console.Write("");
            
            Console.Write("Input Framecount: ");
            input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int framecount) && framecount > 0) return framecount;
        }

        return -1;
    }
}