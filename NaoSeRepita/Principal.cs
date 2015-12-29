using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NaoSeRepita
{
    public partial class Principal : WindowBase
    {
        #region TIPOS_MUSICAS
        private const string TIPO_MP3 = ".mp3";
        private const string TIPO_WMA = ".wma";
        private const string TIPO_MP4 = ".mp4";
        private const string TIPO_M4A = ".m4a";
        private const string TIPO_MIDI = ".midi";
        #endregion

        private string CaminhoDiretorio { get; set; }
        private Configuracoes Configuracoes { get; set; }
        private List<string> ListagemArquivos = new List<string>();

        //Variável utilizada para evitar que o MudarMusica seja executado duas vezes
        //seguidas, pois o evento plyPrincipal_PlayStateChange é chamado duas vezes
        //seguidas com o status 8
        private bool PrimeiraVezPassandoFimMusica { get; set; }

        public Principal()
        {
            InitializeComponent();
            PrimeiraVezPassandoFimMusica = true;
            plyPrincipal.PlayStateChange += plyPrincipal_PlayStateChange;
            Configuracoes = new Configuracoes();
            ListagemArquivos = Configuracoes.CarregarListagem();
            CaminhoDiretorio = Configuracoes.DiretorioMusicas();
            if (ListagemArquivos.Count > 0)
                RefreshListBox();
        }

        /// <summary>
        /// Retoma a execução da listagem, caso houver uma nas configurações. Solicita caminho do diretório
        /// com as músicas, caso não haja uma configuração salva ou ela não tenha sido resetada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (ListagemArquivos.Count > 0)
            {
                MudarMusica();
            }

            else
            {
                if (fbdDiretorioMusicas.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    CaminhoDiretorio = fbdDiretorioMusicas.SelectedPath;
                    foreach (string arquivo in Directory.EnumerateFiles(CaminhoDiretorio))
                        if (TipoValido(arquivo))
                            ListagemArquivos.Add(Path.GetFileName(arquivo));

                    Configuracoes.SalvarListagemAtual(CaminhoDiretorio, ListagemArquivos);
                    MudarMusica();
                }
            }
        }

        /// <summary>
        /// Método usado para controlar o que ocorre quando o estado de execução do arquivo de mídia é modificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plyPrincipal_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            #region PossibleStates
            //case 0:    // Undefined

            //case 1:    // Stopped

            //case 2:    // Paused

            //case 3:    // Playing

            //case 4:    // ScanForward

            //case 5:    // ScanReverse

            //case 6:    // Buffering

            //case 7:    // Waiting

            //case 8     // MediaEnded

            //case 9:    // Transitioning

            //case 10:   // Ready

            //case 11:   // Reconnecting

            //case 12:   // Last
            #endregion

            try
            {
                switch ((WMPLib.WMPPlayState)e.newState)
                {
                    case WMPLib.WMPPlayState.wmppsMediaEnded: //MediaEnded
                        {
                            if (PrimeiraVezPassandoFimMusica)
                                MudarMusica();
                            PrimeiraVezPassandoFimMusica = false;
                            break;
                        }

                    case WMPLib.WMPPlayState.wmppsReady: //Ready
                        {
                            plyPrincipal.Ctlcontrols.play();
                            break;
                        }

                    default:
                        {
                            PrimeiraVezPassandoFimMusica = true;
                            break;
                        }
                }
            }

            catch (COMException comException) //Mídia inválida
            {
                
            }
        }

        /// <summary>
        /// Muda a música atualmente em execução
        /// </summary>
        private void MudarMusica()
        {
            if (ListagemArquivos.Count == 0 && !string.IsNullOrEmpty(CaminhoDiretorio))
                foreach (string arquivo in Directory.EnumerateFiles(CaminhoDiretorio))
                    if (TipoValido(arquivo))
                        ListagemArquivos.Add(Path.GetFileName(arquivo));

            int indice = new Random().Next(0, ListagemArquivos.Count - 1);
            plyPrincipal.URL = CaminhoDiretorio + "/" + ListagemArquivos[indice];
            ListagemArquivos.RemoveAt(indice);
            RefreshListBox();
            Configuracoes.SalvarListagemAtual(CaminhoDiretorio, ListagemArquivos);
        }

        /// <summary>
        /// Lê a quantidade de músicas na listagem e a insere no label
        /// </summary>
        private void RecarregarLabelQuantidade()
        {
            lblQuantidade.Text = ListagemArquivos.Count.ToString();
        }

        private void TratarListagemVazia()
        {

        }

        /// <summary>
        /// Informa se o tipo do arquivo é um tipo válido de arquivo de áudio (mp3, wma, mp4, m4a ou midi)
        /// </summary>
        /// <param name="arquivo">Pode conter o caminho completo do arquivo ou apenas o nome, mas deve conter a extensão do arquivo</param>
        /// <returns>True se o arquivo tiver extensão válida, false se não tiver</returns>
        private bool TipoValido(string arquivo)
        {
            return arquivo.EndsWith(TIPO_MP3) ||
                    arquivo.EndsWith(TIPO_WMA) ||
                    arquivo.EndsWith(TIPO_MP4) ||
                    arquivo.EndsWith(TIPO_M4A) ||
                    arquivo.EndsWith(TIPO_MIDI);
        }

        /// <summary>
        /// Caso ocorra um erro ao executar o arquivo. Encerra a execução dos arquivos, para evitar que fique eternamente etentando executar o próximo arquivo
        /// nos casos de dispositivo de áudio inexistente (quando o fone de ouvido é desconectado e não há outro dispositivo de saída de áudio, por exemplo).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plyPrincipal_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            MessageBox.Show("Mídia inválida ou impossível de executar. Verifique dispositivos de saída de áudio.", "Não se Repita - Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            plyPrincipal.Ctlcontrols.stop();
        }

        /// <summary>
        /// Método para dar um refresh na ListBox
        /// </summary>
        private void RefreshListBox()
        {
            lbxMusicas.DataSource = null;
            lbxMusicas.DataSource = ListagemArquivos;
            RecarregarLabelQuantidade();
        }

        /// <summary>
        /// Reseta a listagem de músicas, para o clique no Iniciar não sair inicializando as músicas
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ListagemArquivos = new List<string>();
            CaminhoDiretorio = string.Empty;
            Configuracoes.SalvarListagemAtual(CaminhoDiretorio, ListagemArquivos);
            RefreshListBox();
        }

        /// <summary>
        /// Executa o próximo áudio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProxima_Click(object sender, EventArgs e)
        {
            MudarMusica();
        }
    }
}