using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using System.Windows.Automation;

namespace addressbook_test_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE ="Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
             Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData() { Name = item.Text });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add (GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
           TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            //aux.Send(newGroup.Name);
            //aux.Send("{ENTER}");
            CloseGroupsDialogue(dialogue);
        }

        public Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("GroupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
        public void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

    }

}