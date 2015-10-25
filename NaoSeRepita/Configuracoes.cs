using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace NaoSeRepita
{
    public class Configuracoes
    {
        #region Constantes de Controle da Estrutura de Diretórios
        private const string DIRETORIO_CONFIGURACOES = "Configuracoes";
        private const string ARQUIVO_CONFIGURACOES = "Configuracoes.xml";
        private const string ARQUIVO_LISTAGEM_MUSICAS = "ListagemMusicas.xml";
        private const string DIRETORIO_NAO_SE_REPITA = "NaoSeRepita";
        #endregion

        #region Constantes para controle das conversões de e para XML
        private const string PARA_E_COMERCIAL = "amp;";
        private const string DE_E_COMERCIAL = "&";
        #endregion

        /// <summary>
        /// Obtém Diretório que contém as músicas da listagem salva nas configurações
        /// </summary>
        /// <returns>Diretório de músicas salvo nas configurações ou vazio, caso não seja encontrado um arquivo de configurações</returns>
        public string DiretorioMusicas()
        {
            if (!File.Exists(ObterLocalCompletoArquivoListagem()))
                return string.Empty;

            XmlDocument documento = new XmlDocument();
            documento.Load(ObterLocalCompletoArquivoListagem());
            return documento["NaoSeRepita"]["Diretorio"].InnerText;
        }

        /// <summary>
        /// Obtém Listagem de músicas salva nas configurações
        /// </summary>
        /// <returns>Listagem com nome dos arquivos de música lidos no XML, ou uma listagem vazia, caso não haja um arquivo de configurações</returns>
        public void SalvarListagemAtual(string diretorio, List<string> listagem)
        {
            string xml = string.Format("<NaoSeRepita><Diretorio>{0}</Diretorio>", diretorio);
            xml += "<ListagemMusicas>";
            foreach (string item in listagem)
                xml += string.Format("<Musica>{0}</Musica>", TratarStringParaArquivo(item));
            xml += "</ListagemMusicas>";
            xml += "</NaoSeRepita>";
            XmlDocument documento = new XmlDocument();
            documento.LoadXml(xml);
            documento.Save(ObterLocalCompletoArquivoListagem());
        }

        /// <summary>
        /// Carrega listagem de músicas salva nas configurações
        /// </summary>
        /// <returns>Listagem com nomes dos arquivos</returns>
        public List<string> CarregarListagem()
        {
            List<string> listagemMusicas = new List<string>();

            if (!File.Exists(ObterLocalCompletoArquivoListagem()))
                return listagemMusicas;

            XmlDocument documento = new XmlDocument();
            documento.Load(ObterLocalCompletoArquivoListagem());

            foreach (XmlNode nodo in documento["NaoSeRepita"]["ListagemMusicas"].GetElementsByTagName("Musica"))
                listagemMusicas.Add(TratarStringParaListagem(nodo.InnerText));

            return listagemMusicas;
        }

        /// <summary>
        /// Obtém caminho completo do diretório do NaoSeRepita no AppData do usuário logado
        /// </summary>
        /// <returns>Caminho completo do diretório AppData do usuário logado</returns>
        private string ObterDiretorioLocal()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + DIRETORIO_NAO_SE_REPITA))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + DIRETORIO_NAO_SE_REPITA);

            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + DIRETORIO_NAO_SE_REPITA;
        }

        /// <summary>
        /// Obtém caminho completo do diretório de configurações
        /// </summary>
        /// <returns>Caminho completo do diretório de configurações</returns>
        private string ObterDiretorioConfiguracoes()
        {
            if (!Directory.Exists(ObterDiretorioLocal() + "/" + DIRETORIO_CONFIGURACOES))
                Directory.CreateDirectory(ObterDiretorioLocal() + "/" + DIRETORIO_CONFIGURACOES);

            return ObterDiretorioLocal() + "/" + DIRETORIO_CONFIGURACOES;
        }

        /// <summary>
        /// Obtém caminho completo do arquivo de configurações da listagem atualmente em execução
        /// </summary>
        /// <returns>Caminho completo do arquivo de configurações da listagem atualmente em execução</returns>
        private string ObterLocalCompletoArquivoListagem()
        {
            return ObterDiretorioConfiguracoes() + "/" + ARQUIVO_LISTAGEM_MUSICAS;
        }

        /// <summary>
        /// Altera uma string para um formato interpretável como InnetText da classe XmlDocument
        /// </summary>
        /// <returns>String convertida para um formato possível se ser salvo como arquivo XML</returns>
        private string TratarStringParaArquivo(string conteudo)
        {
            return conteudo.Replace(DE_E_COMERCIAL, PARA_E_COMERCIAL);
        }

        /// <summary>
        /// Altera uma string convertida pelo método TratarStringParaArquivo para seu formato original
        /// </summary>
        /// <returns>String restaurada de uma conversão para XML</returns>
        private string TratarStringParaListagem(string conteudo)
        {
            return conteudo.Replace(PARA_E_COMERCIAL, DE_E_COMERCIAL);
        }
    }
}