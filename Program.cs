using System;
///
// Control de fechas para periodos
///

//Fecha de registro de un cliente

var fechaProximoPago = GetPeriodoB(new DateTime(2021, 02,28), 12);
//Output: 28/02/2022 12:00:00 a. m.

System.Console.WriteLine(fechaProximoPago);

DateTime GetPeriodoB(DateTime PeriodoA, int Meses)
{
    //Simulando una consulta a base de datos para Obtener su fecha de instalado del cliente
    var FechaRegistro = new DateTime(2020, 02,29);

    //En caso de querer validar esto se puede separar a nivel de aplicación
    if (DateTime.Compare(FechaRegistro,PeriodoA) > 0)
        throw new ArgumentException("La fecha de pago no puede ser menor a la fecha de instalación");
    
    //En base a la consulta anterior se obtiene el dia del mes que se registro
    int FechaCorte = int.Parse(FechaRegistro.ToString("dd"));

    //Simulando una consulta en base de datos de la ultima fecha de pago
    var ProximoPago = PeriodoA;

    //En base a la consulta anterior se agrega un mes
    ProximoPago = ProximoPago.AddMonths(Meses);

    //Obtengo el ultimo dia del mes obtenido en el paso anterior
    var UltimoDiaMes = DateTime.DaysInMonth(int.Parse(ProximoPago.ToString("yyyy")),int.Parse(ProximoPago.ToString("MM")));
    
    //Cuando es final de mes, se puede dar el caso de ser necesario agregar los dias a la fecha obtenida con la funcion anterior
    if (FechaCorte >= UltimoDiaMes)
    {
        var dia = int.Parse(ProximoPago.ToString("dd"));
        dia = UltimoDiaMes - dia;
        ProximoPago = ProximoPago.AddDays(dia);
        return ProximoPago;
    } 

    //Caso cuando la fecha de instalación no es a final de mes
    //Menor al dia 28 de mes
    return ProximoPago;
}