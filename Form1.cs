using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousekeepingService1
{
    public partial class Form1 : Form
    {
        User currentUser = null;
        String workType = "";
        String selectedAge = null;
        String selectedGender = null;
        String selectedPrice = null;
        String selectedWorkTime = null;
        int selectedWorkerID = -1;
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        int daySpan = 0;
        int totalPayment = 0;

        public Form1()
        {
            InitializeComponent();
            cbox_age.SelectedIndex = 0;
            cbox_gender.SelectedIndex = 0;
            cbox_price.SelectedIndex = 0;
            cbox_availabletime.SelectedIndex = 0;
            startDate = this.datePicker_startDate.Value;
            endDate = this.datePicker_endDate.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            String username = tb_username.Text.Trim();
            String password = tb_password.Text.Trim();
            currentUser = UserOperation.verifyUser(username, password);
            if (currentUser == null)
            {
                MessageBox.Show("Username and password don't match!");
            }
            else
            {
                pnl_login.Visible = false;
                typepnl_lb_username.Text = currentUser.getUsername();
                pnl_typechoose.Visible = true;

            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pic_tutor_Click(object sender, EventArgs e)
        {
            workType = "tutor";
            pnl_typechoose.Visible = false;
            pnl_workerchoose.Visible = true;
            showWorkerListOfType(workType);
        }

        private void pic_babysiter_Click(object sender, EventArgs e)
        {

            workType = "babysiter";
            pnl_typechoose.Visible = false;
            pnl_workerchoose.Visible = true;
            showWorkerListOfType(workType);
        }

        private void pic_housekeeper_Click(object sender, EventArgs e)
        {
            workType = "housekeeper";
            pnl_typechoose.Visible = false;
            pnl_workerchoose.Visible = true;
            showWorkerListOfType(workType);
        }

        //show all the workers of the particular type
        public void showWorkerListOfType(String workerType)
        {
            List<Worker> workers = new List<Worker>();
            workers = WorkerOperation.getWorkersByType(workerType);
            int num = workers.Count;
            for (int i = 0; i <= num - 1; i++)
            {
                generateNewWorkerItem(i, workers[i].getWorkerID(), workers[i].getName(), workers[i].getImage(), workers[i].getAge(), workers[i].getPrice(), workers[i].getLanguage(), workers[i].getIntroduction());
            }
        }

        //for each worker, contruct panel item and add it to the list
        public void generateNewWorkerItem(int index, int workerID, String name, String imagePath, int age, float price, String language, String introduction)
        {
            //label name
            System.Windows.Forms.Label lb_newworkeritem_name = new Label();
            lb_newworkeritem_name.AutoSize = true;
            lb_newworkeritem_name.Font = new System.Drawing.Font("SketchFlow Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_newworkeritem_name.Location = new System.Drawing.Point(115, 12);
            lb_newworkeritem_name.Name = "lb_workeritem_name" + index;
            lb_newworkeritem_name.Size = new System.Drawing.Size(88, 21);
            lb_newworkeritem_name.TabIndex = 1;
            lb_newworkeritem_name.Text = name;

            //pic box
            System.Windows.Forms.PictureBox picbox_newworkeritem_headpic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picbox_workeritem_headpic)).BeginInit();  //TODO
            //picbox_newworkeritem_headpic.Image = global::HousekeepingService1.Properties.Resources.head1;
            picbox_newworkeritem_headpic.Image = Image.FromFile(Application.StartupPath + imagePath);
            picbox_newworkeritem_headpic.Location = new System.Drawing.Point(7, 6);
            picbox_newworkeritem_headpic.Name = "picbox_workeritem_headpic" + index;
            picbox_newworkeritem_headpic.Size = new System.Drawing.Size(84, 84);
            picbox_newworkeritem_headpic.TabIndex = 0;
            picbox_newworkeritem_headpic.TabStop = false;

            //label priceunit
            System.Windows.Forms.Label lb_newworkeritem_priceunit = new Label();
            lb_newworkeritem_priceunit.AutoSize = true;
            lb_newworkeritem_priceunit.Font = new System.Drawing.Font("SketchFlow Print", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_newworkeritem_priceunit.Location = new System.Drawing.Point(290, 15);
            lb_newworkeritem_priceunit.Name = "lb_workeritem_priceunit" + index;
            lb_newworkeritem_priceunit.Size = new System.Drawing.Size(61, 12);
            lb_newworkeritem_priceunit.TabIndex = 6;
            lb_newworkeritem_priceunit.Text = "$perhour";

            //label price
            System.Windows.Forms.Label lb_newworkeritem_price = new Label();
            lb_newworkeritem_price.AutoSize = true;
            lb_newworkeritem_price.Font = new System.Drawing.Font("SketchFlow Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_newworkeritem_price.Location = new System.Drawing.Point(255, 5);
            lb_newworkeritem_price.Name = "lb_workeritem_price" + index;
            lb_newworkeritem_price.Size = new System.Drawing.Size(44, 26);
            lb_newworkeritem_price.TabIndex = 5;
            lb_newworkeritem_price.Text = price.ToString();

            //label language
            System.Windows.Forms.Label lb_newworkeritem_language = new Label();
            lb_newworkeritem_language.AutoSize = true;
            lb_newworkeritem_language.Location = new System.Drawing.Point(173, 37);
            lb_newworkeritem_language.Name = "lb_workeritem_language" + index;
            lb_newworkeritem_language.Size = new System.Drawing.Size(140, 16);
            lb_newworkeritem_language.TabIndex = 4;
            lb_newworkeritem_language.Text = language;

            //label age
            System.Windows.Forms.Label lb_newworkeritem_age = new Label();
            lb_newworkeritem_age.AutoSize = true;
            lb_newworkeritem_age.Location = new System.Drawing.Point(122, 38);
            lb_newworkeritem_age.Name = "lb_workeritem_age" + index;
            lb_newworkeritem_age.Size = new System.Drawing.Size(28, 16);
            lb_newworkeritem_age.TabIndex = 2;
            lb_newworkeritem_age.Text = age.ToString();

            //label introduction
            System.Windows.Forms.Label lb_newworkeritem_intro = new Label();
            lb_newworkeritem_intro.AutoSize = true;
            lb_newworkeritem_intro.Location = new System.Drawing.Point(95, 59);
            lb_newworkeritem_intro.Name = "lb_workeritem_intro" + index;
            lb_newworkeritem_intro.Size = new System.Drawing.Size(101, 16);
            lb_newworkeritem_intro.TabIndex = 3;
            lb_newworkeritem_intro.Text = introduction;

            //panel
            System.Windows.Forms.Panel pnl_newworkerItem = new Panel();
            pnl_newworkerItem.SuspendLayout();
            this.pnl_workerList.Controls.Add(pnl_newworkerItem);

            pnl_newworkerItem.BackColor = System.Drawing.SystemColors.Info;
            pnl_newworkerItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnl_newworkerItem.Font = new System.Drawing.Font("SketchFlow Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pnl_newworkerItem.Location = new System.Drawing.Point(8, 8); // TODO
            pnl_newworkerItem.Name = "pnl_workerItem+" + workerID;
            pnl_newworkerItem.Size = new System.Drawing.Size(360, 100);
            pnl_newworkerItem.TabIndex = 0;
            pnl_newworkerItem.ResumeLayout(false);
            pnl_newworkerItem.PerformLayout();
            pnl_newworkerItem.Cursor = System.Windows.Forms.Cursors.Hand;
            pnl_newworkerItem.Click += new System.EventHandler(this.workerItem_Click);

            //add components
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_priceunit);
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_price);
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_language);
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_intro);
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_age);
            pnl_newworkerItem.Controls.Add(lb_newworkeritem_name);
            pnl_newworkerItem.Controls.Add(picbox_newworkeritem_headpic);


        }

        private void cbox_age_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnl_workerList.Controls.Clear();
            ComboBox cb = (ComboBox)sender;
            selectedAge = cb.SelectedItem.ToString().Trim();
            if (selectedAge == "All")
            {
                selectedAge = null;
            }
            List<Worker> workers = WorkerOperation.getWorkersByConditions(workType, selectedAge, selectedGender, selectedPrice, selectedWorkTime);
            int num = workers.Count;
            for (int i = 0; i <= num - 1; i++)
            {
                //reloadworkers
                generateNewWorkerItem(i, workers[i].getWorkerID(), workers[i].getName(), workers[i].getImage(), workers[i].getAge(), workers[i].getPrice(), workers[i].getLanguage(), workers[i].getIntroduction());
            }

        }

        private void cbox_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnl_workerList.Controls.Clear();
            ComboBox cb = (ComboBox)sender;
            selectedGender = cb.SelectedItem.ToString().Trim();
            if (selectedGender == "All")
            {
                selectedGender = null;
            }
            List<Worker> workers = WorkerOperation.getWorkersByConditions(workType, selectedAge, selectedGender, selectedPrice, selectedWorkTime);
            int num = workers.Count;
            for (int i = 0; i <= num - 1; i++)
            {
                //reloadworkers
                generateNewWorkerItem(i, workers[i].getWorkerID(), workers[i].getName(), workers[i].getImage(), workers[i].getAge(), workers[i].getPrice(), workers[i].getLanguage(), workers[i].getIntroduction());
            }
        }

        private void cbox_price_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnl_workerList.Controls.Clear();
            ComboBox cb = (ComboBox)sender;
            selectedPrice = cb.SelectedItem.ToString().Trim();
            if (selectedPrice == "All")
            {
                selectedPrice = null;
            }
            if (selectedPrice == "below 20")
            {
                selectedPrice = "0-20";
            }
            if (selectedPrice == "above 50")
            {
                selectedPrice = "50-9999";
            }
            List<Worker> workers = WorkerOperation.getWorkersByConditions(workType, selectedAge, selectedGender, selectedPrice, selectedWorkTime);
            int num = workers.Count;
            for (int i = 0; i <= num - 1; i++)
            {
                //reloadworkers
                generateNewWorkerItem(i, workers[i].getWorkerID(), workers[i].getName(), workers[i].getImage(), workers[i].getAge(), workers[i].getPrice(), workers[i].getLanguage(), workers[i].getIntroduction());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pnl_register.Visible = true;
        }



        private void btn_createNewUser_Click(object sender, EventArgs e)
        {
            String _username = tb_newusername.Text.Trim();
            String _password = tb_newpassword.Text.Trim();
            String _address = tb_newaddress.Text.Trim();
            String _phone = tb_newphone.Text.Trim();

            //check if the user is already exists
            if (UserOperation.isUserExists(_username))
            {
                MessageBox.Show("username already exists!");
            }
            else
            {
                User newUser = new User(_username, _password, _address, _phone, new System.DateTime());
                //add new user
                if (UserOperation.addUser(newUser))
                {
                    MessageBox.Show("Register successfully!");
                    tb_newusername.Text = "";
                    tb_newpassword.Text = "";
                    tb_newaddress.Text = "";
                    tb_newphone.Text = "";
                    this.pnl_register.Visible = false;
                }
                else
                {
                    MessageBox.Show("Register failed! Plase contact the service provider!");
                }
            }
        }


        private void workerItem_Click(object sender, EventArgs e)
        {
            this.pnl_orderConfirm.Visible = true;
            this.pnl_workerchoose.Visible = false;
            Panel currentWorkerItem = (Panel)sender;
            selectedWorkerID = Convert.ToInt16(currentWorkerItem.Name.Split('+')[1]);
           
            //information load
            this.lb_confirm_workertype.Text = this.workType;
            loadWorkerInformation(selectedWorkerID);
        }

        private void datePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            

            DateTimePicker dtp = (DateTimePicker)sender;
            if((dtp.Value.Date.CompareTo(DateTime.Now.Date) == -1)){
                MessageBox.Show("The start time should not be earlier than today!");
                dtp.Value = startDate;
            }
            //if endDate is earlier than startDate, cancel this change
            if (dtp.Value.Date.CompareTo(endDate.Date) == 1)
            {
                MessageBox.Show("The finish time should not be earlier than the start time!");
                dtp.Value = startDate;
            }
            else if (dtp.Value.Date.CompareTo(endDate.Date) == 0)
            {
                startDate = dtp.Value.Date;
                totalPayment = Convert.ToInt16(this.lb_confirm_worker_price.Text);
                pnl_confirm_totalprice.Text = totalPayment.ToString();
            }
            else
            {   
                startDate = dtp.Value.Date;
                daySpan = (endDate.Date - startDate.Date).Days + 1;
                totalPayment = daySpan * (Convert.ToInt16(this.lb_confirm_worker_price.Text));
                pnl_confirm_totalprice.Text = totalPayment.ToString();
            }
        }

        private void datePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            //if endDate is earlier than startDate, cancel this change
            if (dtp.Value.Date.CompareTo(startDate.Date) == -1)
            {
                MessageBox.Show("The finish time should not be earlier than the start time!");
                dtp.Value = endDate.Date;
            }
            else if (dtp.Value.Date.CompareTo(startDate.Date) == 0)
            {
                endDate = dtp.Value.Date;
                totalPayment = Convert.ToInt16(this.lb_confirm_worker_price.Text);
                pnl_confirm_totalprice.Text = totalPayment.ToString();
            }
            else
            {
                endDate = dtp.Value.Date;
                daySpan = (endDate.Date - startDate.Date).Days + 1;
                totalPayment = daySpan * (Convert.ToInt16(this.lb_confirm_worker_price.Text));
                pnl_confirm_totalprice.Text = totalPayment.ToString();
                
            }
        }
   
        //load worker infromation by its workerID
        private void loadWorkerInformation(int workerID)
        {
            Worker selectedworker = WorkerOperation.getWorkerByWorkerID(workerID);
            Company company = CompanyOperation.getCompanyByWorkerID(workerID);
            this.lb_confirm_worker_name.Text = selectedworker.getName();
            this.lb_confirm_worker_price.Text = selectedworker.getPrice().ToString();
            this.lb_confirm_worker_age.Text = selectedworker.getAge().ToString();
            this.lb_confirm_worker_company.Text = company.getName();
            this.pnl_confirm_totalprice.Text = this.lb_confirm_worker_price.Text;
            this.pictureBox1.Image = Image.FromFile(Application.StartupPath + selectedworker.getImage());
            totalPayment = Convert.ToInt16(this.lb_confirm_worker_price.Text);
        }

        //add to cart click
        private void btn_addtocart_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int orderNumber = rd.Next(999999999);
            Order newOrder = new Order(orderNumber, currentUser.getUserID(), selectedWorkerID, "Not Paid", currentUser.getAddress(), "no details.", totalPayment, System.DateTime.Now, startDate.Date, endDate.Date);
            if (OrderOperation.addNewOrder(newOrder))
            {
                MessageBox.Show("Successfully adding the order to your cart!");
                resetAndGoBack();
            }
            else
            {
                MessageBox.Show("Failed to add the order to your cart! Please contact the service provider!");
            }
        }

        //pay click
        private void btn_pay_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int orderNumber = rd.Next(999999999);
            Order newOrder = new Order(orderNumber, currentUser.getUserID(), selectedWorkerID, "Paid", currentUser.getAddress(), "no details.", totalPayment, System.DateTime.Now, startDate.Date, endDate.Date);
            if (OrderOperation.addNewOrder(newOrder))
            {
                MessageBox.Show("Successfully Paid!");
                resetAndGoBack();
            }
            else
            {
                MessageBox.Show("Failed to pay the order! Please contact the service provider!");
            }
        }

        //rest the attributes and ui
        private void resetAndGoBack()
        {
            //global attr reset
            this.workType = "";
            this.selectedAge = null;
            this.selectedGender = null;
            this.selectedPrice = null;
            this.selectedWorkTime = null;
            this.selectedWorkerID = -1;
            this.startDate = new DateTime();
            this.endDate = new DateTime();
            this.daySpan = 0;
            this.totalPayment = 0;
            //ui reset
            this.pnl_typechoose.Visible = true;
            this.pnl_workerchoose.Visible = false;
            this.pnl_orderConfirm.Visible = false;
            this.datePicker_endDate.Value = System.DateTime.Now;
            this.datePicker_startDate.Value = System.DateTime.Now;
            this.pnl_workerList.Controls.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.pnl_typechoose.Visible = false;
            this.pnl_order.Visible = true;
            loadOrderList(this.currentUser.getUserID());
            lb_order_username.Text = this.currentUser.getUsername();
        }

        //load all the orders of a particular user
        private void loadOrderList(int userID)
        {
        
            this.pnl_orderlist.Controls.Clear();
            //read orders from db through userID
            List<Order> orders = OrderOperation.getOrdersByUserID(userID);
            for (int i = 0; i <= orders.Count - 1; i++ )
            {
                //get worker by orderID
                Worker item_worker = WorkerOperation.getWorkerByOrderID(orders[i].getOrderID());
                generateOrderItem(orders[i], item_worker);
            }
        }

        private void generateOrderItem(Order orderInfo, Worker workerInfo)
        {
            //panel
            System.Windows.Forms.Panel pnl_neworderitem = new Panel();
            pnl_neworderitem.SuspendLayout();
            pnl_neworderitem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

            pnl_neworderitem.Location = new System.Drawing.Point(8, 8);
            pnl_neworderitem.Name = "pnl_orderitem+" + orderInfo.getOrderID();
            pnl_neworderitem.Size = new System.Drawing.Size(680, 90);
            pnl_neworderitem.TabIndex = 0;

            //add panel to list
            this.pnl_orderlist.Controls.Add(pnl_neworderitem);

            //pic
            System.Windows.Forms.PictureBox picbox_neworderitem_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picbox_neworderitem_pic)).BeginInit();
            picbox_neworderitem_pic.Image = Image.FromFile(Application.StartupPath + workerInfo.getImage());
            picbox_neworderitem_pic.Location = new System.Drawing.Point(8, 3);
            picbox_neworderitem_pic.Name = "picbox_orderitem_pic+" + orderInfo.getOrderID();
            picbox_neworderitem_pic.Size = new System.Drawing.Size(85, 85);
            picbox_neworderitem_pic.TabIndex = 0;
            picbox_neworderitem_pic.TabStop = false;

            //workername
            System.Windows.Forms.Label lb_orderitem_newworkername = new Label();
            lb_orderitem_newworkername.AutoSize = true;
            lb_orderitem_newworkername.Font = new System.Drawing.Font("SketchFlow Print", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_orderitem_newworkername.Location = new System.Drawing.Point(119, 14);
            lb_orderitem_newworkername.Name = "lb_orderitem_workername+" + orderInfo.getOrderID();
            lb_orderitem_newworkername.Size = new System.Drawing.Size(67, 27);
            lb_orderitem_newworkername.TabIndex = 1;
            lb_orderitem_newworkername.Text = workerInfo.getName();

            //workerType
            System.Windows.Forms.Label lb_orderitem_newworketype = new Label();
            lb_orderitem_newworketype.AutoSize = true;
            lb_orderitem_newworketype.Font = new System.Drawing.Font("SketchFlow Print", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_orderitem_newworketype.ForeColor = System.Drawing.Color.Red;
            lb_orderitem_newworketype.Location = new System.Drawing.Point(145, 57);
            lb_orderitem_newworketype.Name = "lb_orderitem_worketype+" + orderInfo.getOrderID();
            lb_orderitem_newworketype.Size = new System.Drawing.Size(172, 27);
            lb_orderitem_newworketype.TabIndex = 2;
            lb_orderitem_newworketype.Text = workerInfo.getType();

            //label
            System.Windows.Forms.Label newlabel5 = new Label();
            newlabel5.AutoSize = true;
            newlabel5.Font = new System.Drawing.Font("SketchFlow Print", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newlabel5.Location = new System.Drawing.Point(480, 30);
            newlabel5.Name = "label5+" + orderInfo.getOrderID();
            newlabel5.Size = new System.Drawing.Size(29, 27);
            newlabel5.TabIndex = 5;
            newlabel5.Text = "$";


            //service period
            System.Windows.Forms.Label lb_orderitem_newserviceperiod = new Label();
            lb_orderitem_newserviceperiod.AutoSize = true;
            lb_orderitem_newserviceperiod.Font = new System.Drawing.Font("SketchFlow Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_orderitem_newserviceperiod.Location = new System.Drawing.Point(280, 20);
            lb_orderitem_newserviceperiod.Name = "lb_orderitem_serviceperiod+" + orderInfo.getOrderID();
            lb_orderitem_newserviceperiod.Size = new System.Drawing.Size(250, 21);
            lb_orderitem_newserviceperiod.TabIndex = 3;
            lb_orderitem_newserviceperiod.Text = orderInfo.getStarDate().Date.ToString().Split(' ')[0] + " TO " + orderInfo.getEndDate().Date.ToString().Split(' ')[0];

            //payment
            System.Windows.Forms.Label lb_neworderitem_payment = new Label();
            lb_neworderitem_payment.AutoSize = true;
            lb_neworderitem_payment.Font = new System.Drawing.Font("SketchFlow Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_neworderitem_payment.ForeColor = System.Drawing.Color.Red;
            lb_neworderitem_payment.Location = new System.Drawing.Point(500, 27);
            lb_neworderitem_payment.Name = "lb_orderitem_payment+" + orderInfo.getOrderID();
            lb_neworderitem_payment.Size = new System.Drawing.Size(64, 32);
            lb_neworderitem_payment.TabIndex = 4;
            lb_neworderitem_payment.Text = orderInfo.getPayment().ToString();
            
            //status
            System.Windows.Forms.Label lb_neworderitem_status = new Label();
            lb_neworderitem_status.AutoSize = true;
            lb_neworderitem_status.Font = new System.Drawing.Font("SketchFlow Print", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb_neworderitem_status.ForeColor = System.Drawing.Color.Maroon;
            lb_neworderitem_status.Location = new System.Drawing.Point(570, 27);
            lb_neworderitem_status.Name = "lb_orderitem_status+" + orderInfo.getOrderID();
            lb_neworderitem_status.Size = new System.Drawing.Size(112, 26);
            lb_neworderitem_status.TabIndex = 6;
            lb_neworderitem_status.Text = orderInfo.getOrderStt();

            //pay btn
            System.Windows.Forms.Button btn_neworderitem_pay = new Button();
            btn_neworderitem_pay.Font = new System.Drawing.Font("SketchFlow Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_neworderitem_pay.Location = new System.Drawing.Point(570, 54);
            btn_neworderitem_pay.Name = "btn_orderitem_pay+ " + orderInfo.getOrderID(); ;
            btn_neworderitem_pay.Size = new System.Drawing.Size(98, 25);
            btn_neworderitem_pay.TabIndex = 7;
            btn_neworderitem_pay.Text = "Pay it now!";
            btn_neworderitem_pay.UseVisualStyleBackColor = true;
            btn_neworderitem_pay.Click += new System.EventHandler(this.btn_orderitem_pay_Click);
            if (orderInfo.getOrderStt().Equals("Paid"))
            {
                lb_neworderitem_status.ForeColor = System.Drawing.Color.Green;
                btn_neworderitem_pay.Visible = false;
            }

            pnl_neworderitem.Controls.Add(btn_neworderitem_pay);
            pnl_neworderitem.Controls.Add(lb_neworderitem_status);
            pnl_neworderitem.Controls.Add(newlabel5);
            pnl_neworderitem.Controls.Add(lb_neworderitem_payment);
            pnl_neworderitem.Controls.Add(lb_orderitem_newserviceperiod);
            pnl_neworderitem.Controls.Add(lb_orderitem_newworketype);
            pnl_neworderitem.Controls.Add(lb_orderitem_newworkername);
            pnl_neworderitem.Controls.Add(picbox_neworderitem_pic);
        }

        private void btn_orderitem_pay_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int paid_orderID = Convert.ToInt16(btn.Name.Split('+')[1]);
            btn.Visible = false;
            if (OrderOperation.updateOrderState(paid_orderID, "Paid"))
            {
                btn.Parent.Controls.Find("lb_orderitem_status+" + paid_orderID, false)[0].ForeColor = Color.Green;
                btn.Parent.Controls.Find("lb_orderitem_status+" + paid_orderID, false)[0].Text = "Paid";
                MessageBox.Show("The order is paid successfully!");
            }
            else
            {
                MessageBox.Show("Failed. Please contact the service provider!");
            }
        }

        //back click
        private void lb_order_back_Click(object sender, EventArgs e)
        {
            this.pnl_order.Visible = false;
            this.pnl_typechoose.Visible = true;
        }
    }
}
