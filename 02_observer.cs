interface IObservable {
    void add(IObserver observer);
    void remove(IObserver observer);

    void notify();
}

interface IObserver {
    void update();
}

interface ITemperatureStation {
    int Temperature { get; set; }
}

class WeatherStation : IObservable, ITemperatureStation {

    public int Temperature { 
        get {
            return this.temperature;
        }
        set {
            // avoid useless sets & notifies
            if( this.Temperature != temperature ) {
                this.Temperature = temperature;
                this.notify();
            }
            
        }  
    }

    private ICollection<IObserver> observers;
    private int temperature;

    public WeatherStation(ICollection<IObserver> observers) {
        this.observers = observers;
    }

    public void add(IOBserver observer) {
        this.observers.add(observer);
    }

    public void remove(IOBserver observer) {
        this.observers.remove(observer);
    }

    public void notify() {
        foreach ( IObserver observer in this.observers ) {
            observer.update();
        }
    }
}

class ConsoleTemperatureDisplay : IObserver, IDisplay {
    private ITemperatureStation station;

    public ConsoleTemperatureDisplay(ITemperatureStation station) {
        this.station = station;
    }

    public void update() {
        this.display();
    }

    public void display() {
        Console.WriteLine(this.station.Temperature)
    }
}

class GraphicTemperatureDisplay : IObserver, IDisplay {
    private ITemperatureStation station;

    public GraphicTemperatureDisplay(ITemperatureStation station) {
        this.station = station;
    }

    public void update() {
        this.display();
    }

    public void display() {
        Graphic.render(this.station.temperature)
    }
}

ITemperatureStation weatherStation = new WeatherStation( new List<IObserver>() );

IObserver consoleTemperatureDisplay = new ConsoleTemperatureDisplay(weatherStation);
IObserver graphicTemperatureDisplay = new GraphicTemperatureDisplay(weatherStation);

weatherStation.add(consoleTemperatureDisplay);
weatherStation.add(graphicTemperatureDisplay);

weatherStation.Temperature = 123
