namespace Musiclasifica.JsonResponse
{

    public class ImageResponse
    {
        public int custom_classes { get; set; }
        public Image[] images { get; set; }
        public int images_processed { get; set; }
    }

    public class Image
    {
        public Classifier[] classifiers { get; set; }
        public string resolved_url { get; set; }
        public string source_url { get; set; }
    }

    public class Classifier
    {
        public Class1[] classes { get; set; }
        public string classifier_id { get; set; }
        public string name { get; set; }
    }

    public class Class1
    {
        public string Class { get; set; }
        public float score { get; set; }
    }

}