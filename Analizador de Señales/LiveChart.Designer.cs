namespace Analizador_de_Señales
{
    partial class LiveChart
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picSeries = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // picSeries
            // 
            this.picSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSeries.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picSeries.Location = new System.Drawing.Point(-1, 0);
            this.picSeries.Name = "picSeries";
            this.picSeries.Size = new System.Drawing.Size(500, 250);
            this.picSeries.TabIndex = 0;
            this.picSeries.TabStop = false;
            this.picSeries.Paint += new System.Windows.Forms.PaintEventHandler(this.picSeries_Paint);
            this.picSeries.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSeries_MouseDown);
            this.picSeries.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSeries_MouseMove);
            this.picSeries.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSeries_MouseUp);
            this.picSeries.Resize += new System.EventHandler(this.picSeries_Resize);
            // 
            // toolTip1
            // 
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // LiveChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picSeries);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(999999, 250);
            this.MinimumSize = new System.Drawing.Size(0, 250);
            this.Name = "LiveChart";
            this.Size = new System.Drawing.Size(498, 250);
            this.Load += new System.EventHandler(this.LiveChart_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LiveChart_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LiveChart_MouseDown);
            this.Resize += new System.EventHandler(this.LiveChart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSeries;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
