using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace TestStudentList
{
    public class UnitTest1
    {
        [Fact]
        public async void A_test_add_student_button()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var ExpectedText = "Шпаков Евгений";

            await Task.Delay(100);
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "InputTB");

            textbox.Text = "Шпаков Евгений";
            B_Add.Command.Execute(B_Add.CommandParameter);

            var Text_Block = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(t => t.Name == "FIOTB");

            Assert.True(Text_Block.Text.Equals(ExpectedText));

            await Task.Delay(50);

        }
        [Fact]
        public async void B_test_save_and_load_buttons()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var ExpectedText = "Шпаков Евгений";

            await Task.Delay(100);
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var B_Save = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButSave");
            var B_Load = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButLoad");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "InputTB");

            textbox.Text = "Шпаков Евгений";
            B_Add.Command.Execute(B_Add.CommandParameter);
            B_Save.Command.Execute(B_Save.CommandParameter);
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            B_Load.Command.Execute(B_Load.CommandParameter);

            var Text_Block = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(t => t.Name == "FIOTB");

            Assert.True(Text_Block.Text.Equals(ExpectedText));

            await Task.Delay(50);
        }
        [Fact]
        public async void C_test_delete_button()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();

            var listBoxItems = listBox.GetVisualDescendants().OfType<ListBoxItem>();

            var But_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "InputTB");

            textbox.Text = "Шпаков Евгений";
            B_Add.Command.Execute(B_Add.CommandParameter);
            textbox.Text = "Шпаков Евгений";
            But_Dell.Command.Execute(But_Dell.CommandParameter);
            listBox.SelectedIndex = 0;
            Assert.True(listBoxItems.Count() == 0);

            await Task.Delay(50);
        }
        [Fact]
        public async void D_test_zero_of_subject_Fiz()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            int Expected = 0;

            await Task.Delay(100);

            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBFiz");

            Combo.SelectedIndex = 0;
            B_Add.Command.Execute(B_Add.CommandParameter);

            var ComboRes = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "ComboFiz");
            Assert.True(ComboRes.SelectedIndex.Equals(Expected));

            await Task.Delay(50);
        }
        [Fact]
        public async void G_Check_Red_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var Expected = "Red";

            await Task.Delay(100);

           
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBFiz");

            Combo.SelectedIndex = 0;
            B_Add.Command.Execute(B_Add.CommandParameter);
            var Rec = mainWindow.GetVisualDescendants().OfType<Rectangle>().First(b => b.Name == "ComboFizRec");
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            Assert.True(Rec.Fill.ToString().Equals(Expected));

            await Task.Delay(50);
        }

        [Fact]
        public async void H_Check_Yellow_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var Expected = "Yellow";

            await Task.Delay(100);


            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBFiz");

            Combo.SelectedIndex = 1;
            B_Add.Command.Execute(B_Add.CommandParameter);
            var Rec = mainWindow.GetVisualDescendants().OfType<Rectangle>().First(b => b.Name == "ComboFizRec");
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            Assert.True(Rec.Fill.ToString().Equals(Expected));

            await Task.Delay(50);
        }

        [Fact]
        public async void I_Check_Green_Color()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var Expected = "Green";

            await Task.Delay(100);


            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBFiz");

            Combo.SelectedIndex = 2;
            B_Add.Command.Execute(B_Add.CommandParameter);
            var Rec = mainWindow.GetVisualDescendants().OfType<Rectangle>().First(b => b.Name == "ComboFizRec");
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            Assert.True(Rec.Fill.ToString().Equals(Expected));

            await Task.Delay(50);
        }
        [Fact]
        public async void J_test_one_of_subject_mat()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            int Expected = 1;

            await Task.Delay(100);

            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBMat");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");

            Combo.SelectedIndex = 1;
            B_Add.Command.Execute(B_Add.CommandParameter);

            var ComboRes = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "ComboMat");
            Assert.True(ComboRes.SelectedIndex.Equals(Expected));
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            await Task.Delay(50);
        }
        [Fact]
        public async void K_test_Color_of_Average_Red()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var Expected = "Red";

            await Task.Delay(100);


            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButAdd");
            var B_Dell = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "ButDell");
            var Combo = mainWindow.GetVisualDescendants().OfType<ComboBox>().First(b => b.Name == "InputCBFiz");

            Combo.SelectedIndex = 0;
            B_Add.Command.Execute(B_Add.CommandParameter);
            var Rec = mainWindow.GetVisualDescendants().OfType<Rectangle>().First(b => b.Name == "TBRecAllAverFiz");
            B_Dell.Command.Execute(B_Dell.CommandParameter);
            Assert.True(Rec.Fill.ToString().Equals(Expected));

            await Task.Delay(50);
        }
    }
}