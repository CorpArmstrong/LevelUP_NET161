using CollectionsTutorial.LightweightCollections.Generic.LinkedList;
using CollectionsTutorial.Utils;

namespace CollectionsTutorial.Demo
{
    class DoublyLinkedListDemo
    {
        public void RunDemo()
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            // 1) AddToBegin
            doublyLinkedList.AddToBegin("aaa");
            doublyLinkedList.AddToBegin("bbb");
            doublyLinkedList.AddToBegin("ccc");
            GUIUtils.ShowMessage(doublyLinkedList.PrintList());

            // 2) AddAfter
            GUIUtils.ShowMessage(string.Format("Add after {0}: {1}", 1, doublyLinkedList.AddAfter(1, "BBB")));
            GUIUtils.ShowMessage(doublyLinkedList.PrintList());

            // 3) AddBefore
            GUIUtils.ShowMessage(string.Format("Add before {0}: {1}", 1, doublyLinkedList.AddBefore(1, "_b_")));
            GUIUtils.ShowMessage(doublyLinkedList.PrintList());

            //// 4) AddToEnd
            //GUIUtils.ShowMessage("Add to end:");
            //doublyLinkedList.AddToEnd("endstring");
            //GUIUtils.ShowMessage(doublyLinkedList.PrintList());

            //// 5) GetFromBegin
            //GUIUtils.ShowMessage(string.Format("Get from begin: {0}", doublyLinkedList.ExtractFromBegin()));
            //GUIUtils.ShowMessage(doublyLinkedList.PrintList());

            InputUtils.WaitForInput();
        }
    }
}
