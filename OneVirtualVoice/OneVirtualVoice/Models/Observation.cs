using System;

namespace OneVirtualVoice.Models
{
    public class Observations
    {
        public ObservationEntry[] Entry { get; set; }
    }

    public class ObservationEntry
    {
        public ObservationResource Resource { get; set; }
    }

    public class ObservationResource
    {
        public Code Code { get; set; }
        public DateTime EffectiveDateTime { get; set; }
        public ValueQuantity ValueQuantity { get; set; }
    }

    public class Code
    {
        public string Text { get; set; }
    }

    public class ValueQuantity
    {
        public float Value { get; set; }
        public string Unit { get; set; }
    }
}