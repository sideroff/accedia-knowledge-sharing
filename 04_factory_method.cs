interface IAnimal {
    void eat();
}

class Dog: IAnimal {
    void eat() {
        Console.WriteLine("Dog is eating.");
    }
}

class Cat: IAnimal {
    void eat() {
        Console.WriteLine("Cat is eating.");
    }
}

class Duck: IAnimal {
    void eat() {
        Console.WriteLine("Duck is eating.");
    }
}



interface IAnimalFactory {
    IAnimal create();
}

class RandomAnimalFactory : IAnimalFactory {
    public IAnimal create() {
        Random rnd = new Random();
        int number  = rnd.Next(1, 4);

        if (number == 1) return new Dog();
        if (number == 2) return new Cat();
        if (number == 3) return new Duck();
    }
}

class BalancedAnimalFactory : IAnimalFactory {
    private string[] defaultAnimals = ["Dog","Cat","Duck"];
    private string[] leftForBalancing = ["Dog","Cat","Duck"];

    public IAnimal create() {
        if (this.leftForBalancing.length == 0) {
            this.leftForBalancing = Array.Copy(this.defaultAnimals);
        }


        Random rnd = new Random();
        int index  = rnd.Next(0, this.leftForBalancing.length);

        string animalClass = this.leftForBalancing[index];

        this.leftForBalancing.removeAt(index);

        return (IAnimal)Activator.CreateInstance("AssemblyName", animalClass);
    }
}
