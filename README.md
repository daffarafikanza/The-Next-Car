# The-Next-Car

Aplikasi sederhana ini adalah aplikasi yang dibuat tujuannya adalah untuk menjaga keamanan pengemudi.

## Scope & Functionalities

- Apa kegunaan DoorController.cs?
- Apa kegunaan Model Door.cs?
- Apa kegunaan Interface OnDoorChanged ?

## How Does it Works?

Setelah pendeklarasian pada `Item.cs`, dilanjutkan dengan penginisialisasian seluruh bahan sebagai media yang nantinya akan menjadi perwakilan dari variabel yang akan diinputkan oleh pengguna.

```csharp
public Item(int id, string title, int quantity, string type, double price)
        {
            this.id = id;
            this.title = title;
            this.quantity = quantity;
            this.type = type;
            this.price = price;
            this.subtotal = subtotal;
```

Selanjutnya semua bahan akan di buatkan semacam variabel perwakilan untuk input. Dibawah ini, terjadi proses dimana nilai dari subtotal diambil dari perkalian nilai price dengan quantity yang selanjutnya akan mewakili `getSubtotal()`

```csharp
public double getSubTotal()
        {
            subtotal = price * quantity;
            return subtotal;
        }
```

`Calculator.cs` berfungsi sebagai penginisialisasian data dari input akan dimasukan dalam satu list yaitu `listItem`, serta penambahan nilai dari total jika item baru diinputkan ke dalam list secara otomatis

```csharp
private List<Item> listItem;
        private double total = 0;

        public Calculator()
        {
            this.listItem = new List<Item>();
        }

        public void addItem(Item item)
        {
            this.listItem.Add(item);
            this.total += item.getSubTotal();
        }
```

Lalu beralih ke `MainWindow.xaml.cs` sebagai pusat dari semua proses. Dimulai dari pengambilan seluruh bahan-bahan yang digunakan, seperti `listItem`

```csharp
public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            listBox.ItemsSource = calculator.getListItem();
        }
```

Dan akhir proses dari aplikasi kasir sederhana ini ada pada coding berikut

```csharp
private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = itemNameBox.Text;
            int quantity = int.Parse(quantityBox.Text);
            string type = typeBox.Text;
            double price = double.Parse(priceBox.Text);

            Item item = new Item(new Random().Next(), title, quantity, type, price);
            calculator.addItem(item);
            double total = calculator.getTotal();

            totalLabel.Content = String.Format("Rp. {0}", total);

            listBox.Items.Refresh();
        }
```
       
Dimana setelah semua input sudah terbaca, lalu diproses dan di output kan dengan cara ditampilkan dalam `listItem` dan label yang berada pada sudut bawah. Label tersebut menunjukan total dari seluruh item yang di input kan berserta total harga dan keterangan lainnya.
