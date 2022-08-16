namespace CerealREST.Models
{
    public class Cereal
    {
        private int _id;
        private string _name;
        private string _mfr;
        private string _type;
        private int _calories;
        private int _protein;
        private int _fat;
        private int _sodium;
        private double _fiber;
        private double _carbo;
        private int _sugars;
        private int _potass;
        private int _vitamins;
        private int _shelf;
        private double _weight;
        private double _cups;
        private double _rating;
        private byte[] _image;

        public Cereal(int id, string name, string mfr, string type, int calories, int protein, int fat, int sodium, double fiber, double carbo, int sugars, int potass, int vitamins, int shelf, double weight, double cups, double rating, byte[] image)
        {
            _id = id;
            _name = name;
            _mfr = mfr;
            _type = type;
            _calories = calories;
            _protein = protein;
            _fat = fat;
            _sodium = sodium;
            _fiber = fiber;
            _carbo = carbo;
            _sugars = sugars;
            _potass = potass;
            _vitamins = vitamins;
            _shelf = shelf;
            _weight = weight;
            _cups = cups;
            _rating = rating;
            _image = image;
        }

        public Cereal()
        {

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Mfr
        {
            get { return _mfr; }
            set
            {
                _mfr = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public int Calories
        {
            get { return _calories; }
            set { _calories = value; }
        }

        public int Protein
        {
            get { return _protein; }
            set
            {
                _protein = value;
            }
        }

        public int Fat
        {
            get { return _fat; }
            set
            {
                _fat = value;
            }
        }

        public int Sodium
        {
            get { return _sodium; }
            set
            {
                _sodium = value;
            }
        }

        public double Fiber
        {
            get { return _fiber; }
            set
            {
                _fiber = value;
            }
        }

        public double Carbo
        {
            get { return _carbo; }
            set
            {
                _carbo = value;
            }
        }

        public int Sugars
        {
            get { return _sugars; }
            set
            {
                _sugars = value;
            }
        }

        public int Potass
        {
            get { return _potass; }
            set
            {
                _potass = value;
            }
        }

        public int Vitamins
        {
            get { return _vitamins; }
            set
            {
                _vitamins = value;
            }
        }

        public int Shelf
        {
            get { return _shelf; }
            set
            {
                _shelf = value;
            }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public double Cups
        {
            get { return _cups; }
            set
            {
                _cups = value;
            }
        }

        public double Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
            }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {_id}, {nameof(Name)}: {_name}, {nameof(Mfr)}: {_mfr}, " +
                $"{nameof(Type)}: {_type}, {nameof(Calories)}: {_calories}, {nameof(Protein)}: {_protein}, " +
                $"{nameof(Fat)}: {_fat}, {nameof(Sodium)}: {_sodium}, {nameof(Fiber)}: {_fiber}, " +
                $"{nameof(Carbo)}: {_carbo}, {nameof(Sugars)}: {_sugars}, {nameof(Potass)}: {_potass}, {nameof(Vitamins)}: {_vitamins}, " +
                $"{nameof(Shelf)}: {_shelf}, {nameof(Weight)}: {_weight}, {nameof(Cups)}: {_cups}, {nameof(Rating)}: {_rating}, {nameof(Image)}: {_image}.";
        }
    }
}
