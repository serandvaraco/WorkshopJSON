using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabJson02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            //se presenta el dialogo por defecto para abrir un archivo 
            DialogResult result = openFileDialog1.ShowDialog();
            //si se pulsa diferente de "YES" no hace ninguna acción 
            if (result != DialogResult.OK)
                return;
            ///obtenemos la ruta del archivo seleccionado
            string filePath = openFileDialog1.FileName;

            ///se abre el archivo para lectura y se cierra cuando finaliza el bloque 
            ///para evitar que el archivo se trunque 
            using (System.IO.StreamReader streamReader =
                new System.IO.StreamReader(filePath))
            {
                // se obtiene el contenido del archivo de manera asíncrona 
                var contentFile = await streamReader.ReadToEndAsync();

                //TODO: 3. Convertir JSON a un Objeto Libro 

                //TODO: 4. Asignar valores a las cajas de texto

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            ///presenta dialogo de guardado 
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            //valida si se selecciono OK si no Sale de la instrucción 
            if (dialogResult != DialogResult.OK)
                return;

            //obtiene ruta de archivo a almacenar
            var filePath = saveFileDialog1.FileName;

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
            {
                ///TODO:  1. Extraer información de las cajas de texto 
                ///y agregar al modelo de libro
                var book = new Books();
                book.BookName = txtBookName.Text;

                ///Se obtiene del checkboxListItem 
                ///unicamente los elementos seleccionados 
                var bookTypesChecked = new List<string>();
                foreach (var item in
                    this.booksTypesCLB.CheckedItems)
                {
                    bookTypesChecked.Add(item.ToString()); 
                }

                //TODO: 2. Convertir objeto libro a JSON  
                var jsonObject = string.Empty;

                //se guarda el archivo de texto en formato JSON
                await sw.WriteAsync(jsonObject);
            }
        }
    }
}
