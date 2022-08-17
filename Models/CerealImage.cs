namespace CerealREST.Models
{
    public class CerealImage
    {
        private int _imgId;
        private string _imgName;
        private byte[] _imgData;

        public CerealImage (int imgId, string imgName, byte[] imgData)
        {
            _imgId = imgId;
            _imgName = imgName;
            _imgData = imgData;
        }

        public CerealImage()
        {

        }

        public int ImgId
        {
            get { return _imgId; }
            set { _imgId = value; }
        }

        public string ImgName
        {
            get { return _imgName; }
            set { _imgName = value; }
        }

        public byte[] ImgData
        {
            get { return _imgData; }
            set
            {
                _imgData = value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(ImgId)}: {_imgId}, {nameof(ImgName)}: {_imgName}, {nameof(ImgData)}: {_imgData}";
        }
    }
}
