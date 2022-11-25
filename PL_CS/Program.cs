using System.Text;

ReadFie();


static void ReadFie(){
    string file = @"C:\Users\digis\OneDrive\Documents\Efrain Ignacio Hernandez\layoutUsuarios2.txt";
    if (File.Exists(file))
    {
        StreamReader TextFile=new StreamReader(file);
        string line;
        line = TextFile.ReadLine();
        ML.Result resultErrores = new ML.Result();
        resultErrores.Objects = new List<object>();

        while ((line=TextFile.ReadLine()) != null)
        {
            String[] lines = line.Split('|');
            
            ML.Usuario usuario = new ML.Usuario();

            usuario.UserName=lines[0];
            usuario.Nombre=lines[1];
            usuario.ApellidoPaterno=lines[2];
            usuario.ApellidoMaterno=lines[3];
            usuario.Email=lines[4];
            usuario.Password=lines[5];
            usuario.FechaNacimiento=lines[6];
            usuario.Sexo=lines[7];
            usuario.Telefono=lines[8];
            usuario.Celular=lines[9];
            usuario.Curp=lines[10];

            usuario.Rol=new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(lines[11]);

            usuario.Imagen   = null;

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Calle = lines[12];
            usuario.Direccion.NumeroInterior = lines[13];
            usuario.Direccion.NumeroExterior = lines[14];
            usuario.Direccion.Colonia.IdColonia = int.Parse(lines[15]);

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Dato ingresado");
            }
            else
            {

                resultErrores.Objects.Add(
                    "/n No se inserto el Username " + usuario.UserName +
                    "/n No se inserto el Nombre " + usuario.Nombre +
                    "/n No se inserto el ApellidoPaterno " + usuario.ApellidoPaterno +
                    "/n No se inserto el ApellidoMaterno " + usuario.ApellidoMaterno +
                    "/n No se inserto el Email " + usuario.Email +
                    "/n No se inserto el Password " + usuario.Password +
                    "/n No se inserto el FechaNacimiento " + usuario.FechaNacimiento +
                    "/n No se inserto el Sexo " + usuario.Sexo +
                    "/n No se inserto el Telefono " + usuario.Telefono +
                    "/n No se inserto el Celular " + usuario.Celular +
                    "/n No se inserto el Curp " + usuario.Curp +
                    "/n No se inserto el IdRol " + usuario.Rol.IdRol +
                    "/n No se inserto el Imagen " + usuario.Imagen +
                    "/n No se inserto el Calle " + usuario.Direccion.Calle +
                    "/n No se inserto el NumeroExterior " + usuario.Direccion.NumeroExterior +
                    "/n No se inserto el NumeroInterior " + usuario.Direccion.NumeroInterior +
                    "/n No se inserto el IdColonia " + usuario.Direccion.Colonia.IdColonia);
                   
               
            }
            if (resultErrores.Objects != null)
            {

            }
            string error = @"C:\Users\digis\OneDrive\Documents\Efrain Ignacio Hernandez\ErrorCargarMasiva\ErrorCargaMasiva.txt";
            TextWriter sw = new StreamWriter(error);
                foreach (string nerror in resultErrores.Objects)
                {

                    sw.WriteLine(nerror);
                }
            sw.Close();

        }

    }
}