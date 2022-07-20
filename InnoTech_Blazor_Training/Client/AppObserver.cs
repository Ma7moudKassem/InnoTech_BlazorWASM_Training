namespace InnoTech_Blazor_Training.Client
{
    public class AppObserver
    {
        public Action? OnEmpolyeeChanged { get; set; }
        public void EmpolyeeHasChanged() => OnEmpolyeeChanged?.Invoke();
    }
}
