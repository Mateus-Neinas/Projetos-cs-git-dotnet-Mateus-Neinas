namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora;
    public String Data
    {
        get { return _data.ToString(); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }
    public string Hora
    {
        get { return _hora.ToString(@"hh\:mm"); }
        set
        {
            _validarHoraInformada(value);
            _validarHoraValidaParaCompromisso();
        }

    }

    private void _validarDataInformada(string data) {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} Inválida!");
        }
        else
            Console.WriteLine("Verificação de formato de Data bem sucedida!");
    }

    private void _validarDataValidaParaCompromisso() {
        if (_data.Date < DateTime.Now.Date)
        {
            throw new Exception($"Data {_data:dd/MM/yyyy} é inferior à permitida.");
        }
        else
        {
            Console.WriteLine("Verificação de Data Permitida bem sucedida!");
        } 
    }
    private void _validarHoraInformada(string hora)
    {
        if (!TimeSpan.TryParseExact(hora, @"hh\:mm", null, out _hora))
        {
            throw new Exception($"Hora {hora} inválida! Use o formato HH:mm.");
        }
        else
            Console.WriteLine("Verificação formato de hora bem sucedida!");
    }

    private void _validarHoraValidaParaCompromisso()
{
    if (_data.Date == DateTime.Now.Date && _hora <= DateTime.Now.TimeOfDay)
    {
        throw new Exception($"Hora {_hora.ToString(@"hh\:mm")} é inferior à permitida.");
    }
    else
    {
        Console.WriteLine("Verificação de Hora Permitida bem sucedida!");
    }
}

    public DateTime DataHoraCompleta => _data.Date + _hora;

}