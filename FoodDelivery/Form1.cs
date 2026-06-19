using FoodDelivery.Controller;
using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FoodDelivery
{
    public partial class Form1 : Form
    {
        DishesController controller = new DishesController();
        int selectedId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadDishTypes();
            LoadDishes();
        }
        private void LoadDishTypes()
        {
            using (var context = new DishesContext())
            {
                var types = context.DishTypes.ToList();

                cmbDishType.DataSource = null;
                cmbDishType.DataSource = types;
                cmbDishType.DisplayMember = "TypeName";
                cmbDishType.ValueMember = "Id";
            }
        }
        private void LoadDishes()
        {
            dgvDishes.DataSource = controller.GetDishes()
                .Select(x => new
                {
                    x.Id,
                    x.Name
                })
                .ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dish dish = new Dish();

            dish.Name = txtName.Text;
            dish.Description = txtDescription.Text;
            dish.Price = decimal.Parse(txtPrice.Text);
            dish.Grammage = double.Parse(txtGrammage.Text);
            dish.DishTypeId = (int)cmbDishType.SelectedValue;

            controller.Add(dish);

            LoadDishes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDishes.CurrentRow == null)
                return;

            int id = (int)dgvDishes.CurrentRow.Cells["Id"].Value;

            controller.Delete(id);

            LoadDishes();
        }

        private void dgvDishes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDishes.CurrentRow == null)
                return;

            selectedId =
                Convert.ToInt32(dgvDishes.CurrentRow.Cells["Id"].Value);

            Dish dish = controller
                .GetDishes()
                .FirstOrDefault(x => x.Id == selectedId);

            if (dish != null)
            {
                txtName.Text = dish.Name;
                txtDescription.Text = dish.Description;
                txtPrice.Text = dish.Price.ToString();
                txtGrammage.Text = dish.Grammage.ToString();

                cmbDishType.SelectedValue = dish.DishTypeId;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Dish dish = new Dish();

            dish.Id = selectedId;
            dish.Name = txtName.Text;
            dish.Description = txtDescription.Text;
            dish.Price = decimal.Parse(txtPrice.Text);
            dish.Grammage = double.Parse(txtGrammage.Text);
            dish.DishTypeId = (int)cmbDishType.SelectedValue;

            controller.Update(dish);

            LoadDishes();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtGrammage.Clear();

            cmbDishType.SelectedIndex = -1;

            selectedId = 0;
        }

        private void cmbDishType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
