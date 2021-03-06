﻿using System;
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
        private const string INFORMACAO_EM_BRANCO = "--------------------";
        private const string IMAGEM_ALBUM_EM_BRANCO = "images/blank_cd_case.jpg";

        //Variável utilizada para evitar que o MudarMusica seja executado duas vezes
        //seguidas, pois o evento plyPrincipal_PlayStateChange é chamado duas vezes
        //seguidas com o status 8
        private bool PrimeiraVezPassandoFimMusica { get; set; }

        public Principal()
        {
            InitializeComponent();
            lblNomeArquivo.Text = string.Empty;
            PrimeiraVezPassandoFimMusica = true;
            plyPrincipal.PlayStateChange += plyPrincipal_PlayStateChange;
            Configuracoes = new Configuracoes();
            ListagemArquivos = Configuracoes.CarregarListagem();
            CaminhoDiretorio = Configuracoes.DiretorioMusicas();
            if (ListagemArquivos.Count > 0)
                RefreshListBox();

            PreencherSeEmBranco(lblMusicaArquivo);
            PreencherSeEmBranco(lblMusicaNome);
            PreencherSeEmBranco(lblMusicaAlbum);
            PreencherSeEmBranco(lblMusicaArtista);
            PreencherSeEmBranco(lblMusicaAno);
            PreencherSeEmBranco(lblMusicaDuracao);

            using (StreamReader reader = new StreamReader(IMAGEM_ALBUM_EM_BRANCO))
                pbxAlbumArt.Image = Image.FromStream(reader.BaseStream);
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
                CarregarListagem();
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
            string caminhoArquivo = CaminhoDiretorio + "/" + ListagemArquivos[indice];
            plyPrincipal.URL = caminhoArquivo;
            ObterInfoMusica(caminhoArquivo);
            lblNomeArquivo.Text = ListagemArquivos[indice];
            this.Text = ListagemArquivos[indice];
            ListagemArquivos.RemoveAt(indice);
            RefreshListBox();
            Configuracoes.SalvarListagemAtual(CaminhoDiretorio, ListagemArquivos);
        }

        /// <summary>
        /// Obtém informações da música
        /// </summary>
        private void ObterInfoMusica(string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                TagLib.File file = TagLib.File.Create(caminhoArquivo);

                lblMusicaArquivo.Text = Path.GetFileName(file.Name);
                lblMusicaNome.Text = file.Tag.Title;
                lblMusicaAlbum.Text = file.Tag.Album;
                lblMusicaArtista.Text = file.Tag.FirstAlbumArtist;
                if (file.Tag.Year > 0)
                    lblMusicaAno.Text = file.Tag.Year.ToString();
                lblMusicaDuracao.Text = file.Properties.Duration.ToString(@"hh\:mm\:ss");

                PreencherSeEmBranco(lblMusicaNome);
                PreencherSeEmBranco(lblMusicaAlbum);
                PreencherSeEmBranco(lblMusicaArtista);
                PreencherSeEmBranco(lblMusicaAno);

                if (file.Tag.Pictures.FirstOrDefault() != null)
                    using (MemoryStream ms = new MemoryStream(file.Tag.Pictures.FirstOrDefault().Data.Data))
                        pbxAlbumArt.Image = Image.FromStream(ms);
                else
                    using (StreamReader reader = new StreamReader(IMAGEM_ALBUM_EM_BRANCO))
                        pbxAlbumArt.Image = Image.FromStream(reader.BaseStream);
            }
        }

        /// <summary>
        /// Preenche o label se estiver em branco
        /// </summary>
        public void PreencherSeEmBranco(Label label)
        {
            if (string.IsNullOrEmpty(label.Text))
                label.Text = INFORMACAO_EM_BRANCO;
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
            return arquivo.ToLower().EndsWith(TIPO_MP3.ToLower()) ||
                    arquivo.ToLower().EndsWith(TIPO_WMA.ToLower()) ||
                    arquivo.ToLower().EndsWith(TIPO_MP4.ToLower()) ||
                    arquivo.ToLower().EndsWith(TIPO_M4A.ToLower()) ||
                    arquivo.ToLower().EndsWith(TIPO_MIDI.ToLower());
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
            ResetarListagem();
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

        private void ResetarListagem()
        {
            ListagemArquivos = new List<string>();
            CaminhoDiretorio = string.Empty;
            Configuracoes.SalvarListagemAtual(CaminhoDiretorio, ListagemArquivos);
            RefreshListBox();
        }

        private void CarregarListagem()
        {
            CarregarListagem(true);
        }

        private void CarregarListagem(bool autoplay)
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

        private void carregarPorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tags = new List<string>();

            foreach (string arquivo in Directory.EnumerateFiles(CaminhoDiretorio))
                foreach (string tag in TagLib.File.Create(arquivo).Tag.Comment.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    if (!tags.Contains(tag.ToUpperInvariant()))
                        tags.Add(tag.ToUpperInvariant());

            List<string> tagsSelecionadas = new List<string>();
            TagSelection tagSelectionWindow = new TagSelection(tags);
            tagSelectionWindow.ShowDialog();
            tagsSelecionadas = tagSelectionWindow.TagList;

            ListagemArquivos = new List<string>();

            foreach (string arquivo in Directory.EnumerateFiles(CaminhoDiretorio))
                if (MusicaPossuiTag(arquivo, tagsSelecionadas))
                    ListagemArquivos.Add(Path.GetFileName(arquivo));
            MudarMusica();
        }

        private bool MusicaPossuiTag(string arquivo, List<string> tagsSelecionadas)
        {
            using (TagLib.File tagLib = TagLib.File.Create(arquivo))
                foreach (string tag in tagLib.Tag.Comment.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    if (tagsSelecionadas.Contains(tag.ToUpperInvariant()))
                        return true;
            return false;
        }
    }
}