namespace wsimbanaT1.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;

        string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        if (inputText != filteredText)
        {
            entry.Text = filteredText;  
        }


    }

    private void txtNumeroCedula_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;


        string filteredText = new string(inputText.Where(char.IsDigit).ToArray());


        if (inputText != filteredText)
        {
            entry.Text = filteredText;  
        }

    }

    private void txtApellidoPaterno_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;

        string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        if (inputText != filteredText)
        {
            entry.Text = filteredText;
        }

    }

    private void txtApellidoMaterno_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;

        string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        if (inputText != filteredText)
        {
            entry.Text = filteredText;
        }
    }


    private void txtNombres_TextChanged(object sender, TextChangedEventArgs e)
    {

        //var entry = sender as Entry;
        //string inputText = entry.Text;

        //string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        //if (inputText != filteredText)
        //{
        //    entry.Text = filteredText;
        //}

    }

    private void txtNumeroContacto_TextChanged(object sender, TextChangedEventArgs e)
    {

        var entry = sender as Entry;
        string inputText = entry.Text;


        string filteredText = new string(inputText.Where(char.IsDigit).ToArray());


        if (inputText != filteredText)
        {
            entry.Text = filteredText;
        }

    }

    private void txtCorreo1_TextChanged(object sender, TextChangedEventArgs e)
    {

        string email = txtCorreo1.Text?.Trim();
        string confirmEmail = txtCorreo2.Text?.Trim();

        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(confirmEmail))
        {
            if (email != confirmEmail)
            {
                ErrorLabel.Text = "Los correos electrónicos no coinciden.";
                ErrorLabel.IsVisible = true;
            }
            else
            {
                ErrorLabel.IsVisible = false;
            }
        }
        else
        {
            ErrorLabel.IsVisible = false;
        }

    }

    private void txtModalidad_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;

        string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        if (inputText != filteredText)
        {
            entry.Text = filteredText;
        }

    }

    private void txtCampus_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        string inputText = entry.Text;

        string filteredText = new string(inputText.Where(char.IsLetter).ToArray());

        if (inputText != filteredText)
        {
            entry.Text = filteredText;
        }
    }

    private async void btnEnviar_Clicked(object sender, EventArgs e)
    { 
    string tipoDocumento = txtTipoDocumento.Text?.Trim();
    string numeroCedula = txtNumeroCedula.Text?.Trim();
    string apellidoPaterno = txtApellidoPaterno.Text?.Trim();
    string apellidoMaterno = txtApellidoMaterno.Text?.Trim();
    string nombres = txtNombres.Text?.Trim();
    string numeroContacto = txtNumeroContacto.Text?.Trim();
    string correo1 = txtCorreo1.Text?.Trim();
    string correo2 = txtCorreo2.Text?.Trim();
    string modalidad = txtModalidad.Text?.Trim();
    string campus = txtCampus.Text?.Trim();

    if (string.IsNullOrEmpty(tipoDocumento) || string.IsNullOrEmpty(numeroCedula) ||
        string.IsNullOrEmpty(apellidoPaterno) || string.IsNullOrEmpty(nombres) ||
        string.IsNullOrEmpty(correo1) || string.IsNullOrEmpty(correo2))
    {
        await DisplayAlert("Error", "Por favor completa todos los campos obligatorios.", "OK");
        return;
    }

    if (correo1 != correo2)
    {
        await DisplayAlert("Error", "Los correos electrónicos no coinciden.", "OK");
        return;
    }

    string contenido = $"Tipo de Documento: {tipoDocumento}\n" +
                       $"Número de Cédula: {numeroCedula}\n" +
                       $"Apellido Paterno: {apellidoPaterno}\n" +
                       $"Apellido Materno: {apellidoMaterno}\n" +
                       $"Nombres: {nombres}\n" +
                       $"Número de Contacto: {numeroContacto}\n" +
                       $"Correo: {correo1}\n" +
                       $"Modalidad: {modalidad}\n" +
                       $"Campus: {campus}\n" +
                       $"Fecha de Registro: {DateTime.Now}\n\n";

string fileName = "datosFormulario.txt";
string ruta = Path.Combine(FileSystem.AppDataDirectory, fileName);

try
{
    File.AppendAllText(ruta, contenido);
    await DisplayAlert("Éxito", "Datos guardados correctamente.", "OK");
}
catch (Exception ex)
{
    await DisplayAlert("Error", $"No se pudo guardar el archivo: {ex.Message}", "OK");
}
}
}