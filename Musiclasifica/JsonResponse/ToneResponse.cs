namespace Musiclasifica.JsonResponse
{
    public class ToneResponse
    {
        public Document_Tone document_tone { get; set; }
        public Sentences_Tone[] sentences_tone { get; set; }
    }

    public class Document_Tone
    {
        public Tone_Categories[] tone_categories { get; set; }
    }

    public class Tone_Categories
    {
        public Tone[] tones { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
    }

    public class Tone
    {
        public float score { get; set; }
        public string tone_id { get; set; }
        public string tone_name { get; set; }
    }

    public class Sentences_Tone
    {
        public int sentence_id { get; set; }
        public string text { get; set; }
        public int input_from { get; set; }
        public int input_to { get; set; }
        public Tone_Categories1[] tone_categories { get; set; }
    }

    public class Tone_Categories1
    {
        public Tone1[] tones { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
    }

    public class Tone1
    {
        public float score { get; set; }
        public string tone_id { get; set; }
        public string tone_name { get; set; }
    }

}