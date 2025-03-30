// this is code for object oriented programming project
// managing car showroom using delegate, serializaton/deserialization, multiple sorting with comparers and cloning

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

[Flags]
public enum EngineTypeFlag
{
    PETROL=1,
    DIESEL=2,
    ELECTRIC=4
}

public delegate bool Choose<T>(T t);

[Serializable]
public abstract class Car : ICloneable, IComparable<Car>
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public EngineTypeFlag EngineType { get; set; }

    public int YearOfProduction { get; set; }

    public Car(string brand,string model,int yearOfProduction)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
    }
    public object Clone()
    {
        return MemberwiseClone();
    }

    public int CompareTo(Car other)
    {
        if (this is ElectricCar && other is ElectricCar)
        {
            ElectricCar elcectricCar = other as  ElectricCar;
            ElectricCar elcectricCar1 = this as ElectricCar;
            return elcectricCar.BatteryCapacity.CompareTo(electricCar1.BatteryCapacity);
        }
        return this.YearOfProduction.CompareTo(other.YearOfProduction);
    }

    public virtual void DisplayInformation()
    {
        Console.Write($"\nBrand: {Brand}, Model: {Model}, Year of production: {YearOfProduction}");
    }

    public class CarModelComparer :IComparer<Car>
    {
        public int Compare(Car c1,Car c2)
        {
            return c1.Model.CompareTo(c2.Model);
        }
    }
}
[Serializable]
public class CombustionCar : Car
{
    public new object Clone()
    {
        return MemberwiseClone();
    }

    public CombustionCar(string brand, string model, int yearOfProduction, EngineTypeFlag engineType) : base(brand, model, yearOfProduction)
    {
            EngineType = engineType;
        if (engineType == EngineTypeFlag.ELECTRIC)
            throw new ArgumentException("Hybrid cars should be created as hybrids instead of combustion cars!");


    }
    

                

    

    public override void DisplayInformation()
    {
        Console.Write($"\nBrand: {Brand}, Model: {Model}, Year of production: {YearOfProduction} Engine type: {EngineType}");
    }
}
[Serializable]
public class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
    public new object Clone()
    {
        return MemberwiseClone();
    }

    public ElectricCar(string brand, string model, int yearOfProduction,int batteryCapacity) : base(brand, model, yearOfProduction)
    {
        BatteryCapacity = batteryCapacity;
    }

    public override void DisplayInformation()
    {
        Console.Write($"\nBrand: {Brand}, Model: {Model}, Year of production: {YearOfProduction} Battery capacity: {BatteryCapacity} kWh");

    }
}
[Serializable]
public class HybridCar: Car
{   
    public int BatteryCapacity { get; set; }
    public new object Clone()
    {
        return MemberwiseClone();
    }

    public HybridCar(string brand, string model, int yearOfProduction, EngineTypeFlag engineType, int batteryCapacity) : base(brand, model, yearOfProduction)
    {
        if (engineType==EngineTypeFlag.PETROL || engineType==EngineTypeFlag.DIESEL || engineType==EngineTypeFlag.ELECTRIC)
        {
            throw new ArgumentException("Hybrid car has two types of engines!");
        }
        EngineType = engineType;
        BatteryCapacity = batteryCapacity;
    }

    public override void DisplayInformation()
    {
        Console.Write($"\nBrand: {Brand}, Model: {Model}, Year of production: {YearOfProduction} Engine type: {EngineType} Battery capacity: {batteryCapacity} kWh");
    }
}

[Serializable]
public class CarShowroom
{
    List<Car> cars=new List<car>(){ };

    public CarShowroom() { }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        cars.Remove(car);
    }

    public static CarShowroom LoadCarShowroomFromFile(string fileName)
    {
        CarShowroom newShowroom=new CarShowroom();
        FileStream fs = new FileStream(fileName, FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            newShowroom = (CarShowroom)formatter.Deserialize(fs);
            return newShowroom;
        }
        catch (SerializationException e)
        {
            Console.WriteLine("\n\tDeserialization failed: " + e.Message);
            return null;
        }
        finally
        {
            Console.WriteLine("\n\tCar showroom has been loaded from file.");
            fs.Close();
        }

    }
    
    public void SaveCarShowroomToFile(string fileName)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, this);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("\n\tSerialization failed: " + e.Message);
        }
        finally
        {
            Console.WriteLine("\n\tCar showrom has been saved to file.");
            fs.Close();
        }
        
    }

    public void DisplaySorted()
    {
        cars.Sort();
        foreach (Car car in cars)
        {
            car.DisplayInformation();
        }
    }

    public void DisplaySorted(IComparer<Car> comparer)
    {
        cars.Sort(comparer);
        foreach (Car car in cars)
        {
            car.DisplayInformation();
        }
    }

    public void DisplayCars()
    {
        if (cars!=null)
        foreach (Car car in cars)
        {
            car.DisplayInformation();
        }    
    }

    public void DisplayCars(List<Car>list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].DisplayInformation();
        }
    }

    public void DisplayCars(Choose<car> c)
    {
        foreach (Car car in cars)
            {
            if (c(car))
                car.DisplayInformation();
            }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        FileStream filestream = new FileStream("Result.txt", FileMode.Create);
        StreamWriter streamwriter = new StreamWriter(filestream);
        streamwriter.AutoFlush = true;
        Console.SetOut(streamwriter);

        Console.WriteLine("\t\t\t\tBBBBB     M     M    W       W");
        Console.WriteLine("\t\t\t\tB     B    MM   MM    W       W");
        Console.WriteLine("\t\t\t\tB     B    M M M M    W   W   W");
        Console.WriteLine("\t\t\t\tBBBBB      M  M  M    W W W W");
        Console.WriteLine("\t\t\t\tB     B    M     M    WW   WW");
        Console.WriteLine("\t\t\t\tB     B    M     M    W     W");
        Console.WriteLine("\t\t\t\tBBBBB      M     M    W     W");
        Console.WriteLine("\t\t\t\t\tSalon sprzedaży");

        CarShowroom salon = new CarShowroom();

        CombustionCar spalinowy1 = new CombustionCar("BMW", "M3", 2022, EngineTypeFlag.PETROL);
        // creating and adding cars to showroom
        salon.AddCar(spalinowy1);
        salon.AddCar(new CombustionCar("BMW", "M5", 2023, EngineTypeFlag.DIESEL));
        salon.AddCar(new ElectricCar("BMW", "i3", 2022, 60));
        salon.AddCar(new ElectricCar("BMW", "i3", 2022, 70));
        salon.AddCar(new ElectricCar("BMW", "i3", 2022, 93));
        salon.AddCar(new HybridCar("BMW", "330e", 2023, EngineTypeFlag.PETROL | EngineTypeFlag.ELECTRIC, 40));
        salon.AddCar(new CombustionCar("BMW", "X5", 2022, EngineTypeFlag.DIESEL));
        salon.AddCar(new CombustionCar("BMW", "X7", 2023, EngineTypeFlag.PETROL));
        salon.AddCar(new ElectricCar("BMW", "i4", 2022, 70));
        salon.AddCar(new HybridCar("BMW", "530e", 2023, EngineTypeFlag.PETROL | EngineTypeFlag.ELECTRIC, 50));
        salon.AddCar(new CombustionCar("BMW", "M2", 2022, EngineTypeFlag.PETROL));
        salon.AddCar(new CombustionCar("BMW", "M8", 2023, EngineTypeFlag.DIESEL));
        salon.AddCar(new ElectricCar("BMW", "iX3", 2022, 65));
        salon.AddCar(new HybridCar("BMW", "745e", 2023, EngineTypeFlag.PETROL | EngineTypeFlag.ELECTRIC, 45));
        salon.AddCar(new CombustionCar("BMW", "X3", 2022, EngineTypeFlag.DIESEL));
        salon.AddCar(new CombustionCar("BMW", "X6", 2023, EngineTypeFlag.PETROL));
        salon.AddCar(new ElectricCar("BMW", "i8", 2022, 75));
        salon.AddCar(new HybridCar("BMW", "X1 xDrive25e", 2023, EngineTypeFlag.PETROL | EngineTypeFlag.ELECTRIC, 55));
        salon.AddCar(new CombustionCar("BMW", "330i", 2022, EngineTypeFlag.PETROL));
        salon.AddCar(new CombustionCar("BMW", "430i", 2023, EngineTypeFlag.DIESEL));
        salon.AddCar(new ElectricCar("BMW", "iX5", 2022, 80));
        salon.AddCar(new HybridCar("BMW", "X2 xDrive25e", 2023, EngineTypeFlag.PETROL | EngineTypeFlag.ELECTRIC, 60));

        Console.WriteLine("\tAll cars in the showroom:");
        salon.DisplayCars();

        // Testowanie serializacji i deserializacji
        string nazwaPliku = "salon.bin";
        salon.SaveCarShowroomToFile(nazwaPliku);

        Console.WriteLine("\n\tRemoving car from the showroom...");
        salon.RemoveCar(spalinowy1);

        Console.WriteLine("\n\tAll cars in the showroom:");
        salon.DisplayCars();

        CarShowroom wczytanySalon = CarShowroom.LoadCarShowroomFromFile(nazwaPliku);

        Console.WriteLine("\n\tCars loaded from file");
        wczytanySalon.DisplayCars();

        Console.WriteLine("\n\tDisplaying cars matching the parameter (using delegate):");
        salon.DisplayCars((s) => s.Model == "M3");
        salon.DisplayCars((s) => s.Model == "M2");

        Console.WriteLine("\n\tDisplaying cars sored by year of production and electric ones sorted extra by battery capacity descending:");
        salon.DisplaySorted();

        Console.WriteLine("\n\tDisplaying cars sorted by models:");
        salon.DisplaySorted(new Car.CarsModelsComparer());

        Console.WriteLine("\n\tTest of handling exceptions:");
        ExceptionsTester(() => { new CombustionCar("BMW", "M5", 2023, EngineTypeFlag.ELECTRIC); });
        ExceptionsTester(() => { new HybridCar("BMW", "745e", 2023, EngineTypeFlag.PETROL, 45); });
        ExceptionsTester(() => { new HybridCar("BMW", "745e", 2023, EngineTypeFlag.DIESEL, 45); });
        ExceptionsTester(() => { new HybridCar("BMW", "745e", 2023, EngineTypeFlag.ELECTRIC, 45); });

        Console.SetOut(System.IO.TextWriter.Null);
    }

    public delegate void TesterDelegate();

    public static void ExceptionsTester(TesterDelegate test)
    {
        try
        {
            test();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
