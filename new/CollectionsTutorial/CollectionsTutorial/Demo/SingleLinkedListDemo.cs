using CollectionsTutorial.LightweightCollections.Generic.LinkedList;
using CollectionsTutorial.Utils;

namespace CollectionsTutorial.Demo
{
    class SingleLinkedListDemo
    {
        public void RunDemo()
        {
            SingleLinkedList<string> singleLinkedList = new SingleLinkedList<string>();

            // 1) AddToBegin
            singleLinkedList.AddToBegin("aaa");
            singleLinkedList.AddToBegin("bbb");
            singleLinkedList.AddToBegin("ccc");
            GUIUtils.ShowMessage(singleLinkedList.PrintList());

            // 2) RemoveByValue
            GUIUtils.ShowMessage(string.Format("Remove by value: {0}", singleLinkedList.RemoveByValue("bbb")));
            GUIUtils.ShowMessage(singleLinkedList.PrintList());

            // 3) GetValueByPosition
            GUIUtils.ShowMessage(string.Format("Get value by position: {0}", singleLinkedList.GetValueByPosition(1)));
            GUIUtils.ShowMessage(singleLinkedList.PrintList());

            // 4) AddToEnd
            GUIUtils.ShowMessage("Add to end:");
            singleLinkedList.AddToEnd("endstring");
            GUIUtils.ShowMessage(singleLinkedList.PrintList());

            // 5) GetFromBegin
            GUIUtils.ShowMessage(string.Format("Get from begin: {0}", singleLinkedList.ExtractFromBegin()));
            GUIUtils.ShowMessage(singleLinkedList.PrintList());

            InputUtils.WaitForInput();

            #region Enumerator explanation
            //if (list is IEnumerable)
            //{
            //    IEnumerator iter = list.GetEnumerator();

            //    while (iter.MoveNext())
            //    {
            //        Console.Write(iter.Current + "\t");
            //    }
            //}
            #endregion
        }
    }
}
