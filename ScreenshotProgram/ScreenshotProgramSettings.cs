using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotProgram
{
    public class ScreenshotProgramSettings
    {
        public SHMode mode;
        public SaveSettings saveSettings;
        public Keybind keybind;
        public Timer timer;
        public Rectangle FixedFragmentRect;

        public ScreenshotProgramSettings() {
            saveSettings = new SaveSettings();
            keybind = new Keybind();
            timer = new Timer();
            FixedFragmentRect = Rectangle.Empty;
        }
    }

    public class SHAnnoucement
    {
        public bool sound;
        public bool notification;

        public SHAnnoucement()
        {
            sound = true;
            notification = true;
        }
    }

    public class SaveSettings
    {
        public string path;
        public string filename;
        public int index;

        public int pref_save_form;
        public bool save_enabled = true;

        public bool after_editor = false;
        public bool after_clip = false;
        public bool file_loc = false;
        public bool file_op = false;

        public SHAnnoucement annoucement;

        public SaveSettings()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            filename = "screenshot_{i}_{d}-{M}-{y}";
            index = 0;

            annoucement = new SHAnnoucement();
        }
    }

    public class Keybind
    {
        public string key;
        public bool active;

        public Keybind()
        {
            key = "F8";
            active = true;
        }
    }

    public class Timer
    {
        public bool delay_active;
        public bool autoctp_active;
        public int delay;

        public int every;
        public int every_unit;

        public int for_time;
        public int for_time_unit;

        public Timer()
        {
            autoctp_active = false;
            delay_active = false;
            delay = 0;

            every = 0;
            for_time = 0;
            for_time_unit = 0;
            every_unit = 0;
        }
    }

    public enum SHMode
    {
        FullScreen = 0,
        Fragment,
        FixedFragment,
        Window
    }
}
