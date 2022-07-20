namespace InnoTech_Blazor_Training.Client.Pages.Empolyees
{
    public partial class EmpolyeeInformation
    {
        [Parameter] public Empolyee? Empolyee { get; set; }
        private ModelForm? model { get; set; }

        private void CloseForm() => model.Close();

    }
}
