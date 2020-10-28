# The-Next-Car

Aplikasi sederhana ini adalah aplikasi yang dibuat tujuannya adalah untuk menjaga keamanan pengemudi.

## Scope & Functionalities

- Apa kegunaan DoorController.cs?
- Apa kegunaan model Door.cs?
- Apa kegunaan Interface OnDoorChanged ?

## How Does it Works?

1. `DoorController.cs` Berfungsi untuk mengetahui keadaan pintu mobil apakah sudah terkunci atau belum terkunci.

```csharp
namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }
```

2. `model Door.cs` Berfungsi untuk fungsi door closed dan locked.

```csharp
namespace TheNextCar.Model
{
    class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.closed = false;
        }

        public void activateLock()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }

        public bool isLocked()
        {
            return this.locked;
        }

        public bool isClosed()
        {
            return this.closed;
        }
    }
}
```

3. `OnDoorChanged` berfungsi untuk mengganti fungsi Door dan DoorController.

```csharp
public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }
```
