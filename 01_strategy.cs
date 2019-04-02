
interface IFlyingStrategy  {
    void fly();
}

interface ILandingStrategy {
    void land();
}

class Duck {
    private IFlyingStrategy flyingStrategy;
    private ILandingStrategy landingStrategy;

    public Duck(IFlyingStrategy fs, ILandingStrategy ls){
        this.flyingStrategy = fs;
        this.landingStrategy = ls;
    }

    public fly() {
        return this.flyingStrategy.fly();
    }

    public land() {
        return this.landingStrategy.land();
    }
}

class NoFlyingStrategy: IFlyingStrategy {
    public fly() { }
}

class BirdFlyingStrategy: IFlyingStrategy {
    public fly() {
        Console.WriteLine("I am flying!")
    }
}

class NoLandingStrategy: ILandingStrategy {
    public land() {
        Console.WriteLine("I crashed into the ground!")
    }
}

class BirdLandingStrategy: ILandingStrategy {
    public land() {
        Console.WriteLine("I landed gracefully")
    }
}

// Duck rubberDuck = new RubberDuck();
Duck rubberDuck = new Duck(new NoFlyingStrategy(), new NoLandingStrategy());

// Duck wildDuck = new WildDuck();
Duck wildDuck = new Duck(new BirdFlyingStrategy(), new BirdLandingStrategy());

// Robot duck ( can fly, can't land ) = ?
