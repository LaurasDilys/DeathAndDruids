namespace Application.Dto
{
    public class SavableOpenedMonsterViewModel : OpenedMonsterViewModel
    {
        public SavableOpenedMonsterViewModel(int id, int? sourceId, bool saved) : base(id, sourceId)
        {
            Saved = saved;
        }

        public bool Saved { get; set; }
    }
}
