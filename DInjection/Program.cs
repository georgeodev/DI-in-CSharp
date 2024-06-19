namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            Rice rice = new Rice();
            BeefStew beefStew = new BeefStew();
            NigerianJollofRice naijaJollof = new NigerianJollofRice();
            naijaJollof.SetRice(rice);
            naijaJollof.SetStew(beefStew);
            //In interface injection the naijaJollof object is able to use the methods inherited from the IJolloMoker interface
            //to set the value for its properties
            //naijaJollof.Rice = rice;
            //naijaJollof.BeefStew = beefStew;
            //naijaJollof.riceName = rice.name;
            //naijaJollof.stewName = beefStew.name;

            naijaJollof.MakeJollof();
            Console.ReadLine();
        }
    }

    public class Rice
    {
        public readonly string name = "Abakiliki Rice";
        public void Use()
        {
            Console.WriteLine("washing the rice first...");
            Console.WriteLine("boiling the rice...");
        }
    }

    public class Stew
    {
        public Stew() { }
    }
    public class BeefStew : Stew
    {
        public readonly string name = "Iya Teju's Assorted Beef Stew";
        public void Use()
        {
            Console.WriteLine("preparing the ingredients for the stew...");
            Console.WriteLine("getting stew ready for use...");
        }
    }
    public interface IJollofMaker
    {
        void SetRice(Rice rice);
        void SetStew(BeefStew beefStew);
    }
    //In interface injection the class implements properties on an  interface which can be used to inject the dependencies

    public class NigerianJollofRice : IJollofMaker //the NigerianJollofRice class has to implement the properties of the interface (IJollofMaker) before the class can exist
    {

        private Rice _rice;
        private BeefStew _beefStew;
        private string _riceName;
        private string _stewName;

        //THIS IS FOR CONSTRUCTOR INJECTION
        //// Constructor injection is when the dependencies are provided to the class
        //// at object creation through the constructor
        //public NigerianJollofRice(Rice rice, BeefStew beefStew, string riceName, string stewName)
        //{
        //    //_rice = new Rice(); //the jollof rice has to be responsible for the rice and beef stew
        //    //_beefStew = new BeefStew();
        //    _rice = rice;
        //    _beefStew = beefStew;
        //    _riceName = riceName;
        //    _stewName = stewName;
        //}

        //THIS IS FOR SETTER INJECTION
        //public Rice Rice { get; set; }
        //public BeefStew BeefStew { get; set; }
        //public string riceName { get; set; }
        //public string stewName { get; set; }
        //in the setter DI the value of the properties get set from outside of the class by a set method.
        //In the setter DI we can change the dependencies after the object has been created
        // this way a constructor is not needed and it is very good polymorphism.
        public NigerianJollofRice() { } //in setter DI the constructor is not needed. This is just here by default.

        public void MakeJollof()
        {
            _rice.Use();
            _beefStew.Use();
            Console.WriteLine($" {_riceName} was mixed with {_stewName} to make jollof");
        }

        public void SetRice(Rice rice)
        {
            _rice = rice;
            _riceName = rice.name;
        }

        public void SetStew(BeefStew beefStew)
        {
            _beefStew = beefStew;
            _stewName = beefStew.name;
        }
    }

    //// What is Dependency Injection?
    ///DI is a design pattern that is used to achieve inversion or control. Instead
    /// of the class creating its own dependency they are created from the outside.
    /// It helps to follow SOLID's dependency inversion and single responsibility principles.
    /// it also encourages loose coupling of classes with enables maintainability and scalability.
    /// there are 3 types of dependency injection:
    /// 1 - constructor Injection -> Dependencies are provided through a class constructor
    /// setter injection -> the dependencies are provided through a property or a method
    /// interface injection -> provided through an interface that the class implements
}
