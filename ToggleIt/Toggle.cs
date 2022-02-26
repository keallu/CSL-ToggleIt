namespace ToggleIt
{
    public class Toggle
    {
        public int Id { get; set; } = -1;
        public int KeymappingId { get; set; } = 0;
        public string Glyph { get; set; } = string.Empty;
        public bool Enabled { get; set; } = false;
        public bool ShowInPanel { get; set; } = true;
        public bool On { get; set; } = false;

        public Toggle()
        {

        }
    }
}
