using System;

namespace CollectionsTutorial.Utils
{
    public static class InputUtils
    {
        public static void WaitForInput()
        {
            GUIUtils.ShowMessage("Press any key...");
            Console.ReadKey();
        }
    }
}
