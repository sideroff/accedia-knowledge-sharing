interface ICommand {
    void execute();
    void unExecute();
}

class ToggleLampCommand : ICommand {
    Lamp lamp;

    public ToggleLampCommand(Lamp l) {
        this.lamp = l;
    }

    public void execute() {
        this.lamp.toggle();
    }

    public void unExecute() {
        this.execute()
    }
}

class DimLampCommand : ICommand {
    Lamp lamp;

    public ToggleLampCommand(Lamp l) {
        this.lamp = l;
    }

    public void execute() {
        this.lamp.dim();
    }

    public void unExecute() {
        this.lamp.bright()
    }
}


class DimLampCommand : ICommand {
    Lamp lamp;

    public ToggleLampCommand(Lamp l) {
        this.lamp = l;
    }

    public void execute() {
        this.lamp.bright();
    }

    public void unExecute() {
        this.lamp.bright()
    }
}


class Lamp {
    int brightness = 0;

    public void toggle() {
        if ( this.brightness <= 0 ) {
            this.brightness = 5;
            return;
        }

        this.brightness = 0;
    }

    dim() {
        if (this.brightness > 0) {
            this.brightness--;
        }
    }

    bright() {
        if (this.brightness < 10) {
            this.brightness++;
        }
    }

}


class Remote {
    ICommand btn1Command;
    ICommand btn2Command;
    ICommand btn3Command;

    public Remote(Icommand btn1Command, Icommand btn2Command, Icommand btn3Command) {
        this.btn1Command = btn1Command;
        this.btn2Command = btn2Command;
        this.btn3Command = btn3Command;
    }

    public void clickBtn1() {
        this.btn1Command.execute();
    }

    public void clickBtn2() {
        this.btn2Command.execute();
    }

    public void clickBtn3() {
        this.btn3Command.execute();
    }
}



Lamp myLamp = new Lamp();

ICommand toggleLampCommand = new ToggleLampCommand(myLamp);
ICommand dimLampCommand = new DimLampCommand(myLamp);
ICommand brightLampCommand = new BrightLampCommand(myLamp);


Remote myLampRemote = new Remote(toggleLampCommand, dimLampCommand, brightLampCommand);