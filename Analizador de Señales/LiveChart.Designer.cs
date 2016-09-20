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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
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
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(999999, 250);
            this.MinimumSize = new System.Drawing.Size(0, 250);
            this.Name = "LiveChart";
            this.Size = new System.Drawing.Size(498, 250);
            this.Load += new System.EventHandler(this.LiveChart_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LiveChart_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LiveChart_MouseDown);
            this.Resize += new System.EventHandler(this.LiveChart_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
