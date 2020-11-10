using System.Media;

namespace CCL.UI
{
    public static class Sunete
    {
        public static void PlayMesajNou()
        {
            using (SoundPlayer sound = new SoundPlayer(Properties.Resources.MesajNou))
            {
                sound.Play();
            }
        }

        public static void PlayLoginChat()
        {
            using (SoundPlayer sound = new SoundPlayer(Properties.Resources.LoginChat))
            {
                sound.Play();
            }
        }

        public static void PlayLogoutChat()
        {
            using (SoundPlayer sound = new SoundPlayer(Properties.Resources.LogoutChat))
            {
                sound.Play();
            }
        }
    }
}
