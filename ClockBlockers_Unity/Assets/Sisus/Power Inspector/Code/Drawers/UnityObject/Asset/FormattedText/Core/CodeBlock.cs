﻿using System.Text;

namespace Sisus
{
	/// <summary>
	/// Represents a distinct block of C# code which uses a certain
	/// kind of syntax formatting or represents a single line break (\r\n or \r)
	/// </summary>
	public class CodeBlock
	{
		private CodeBlockType type;
		private string content;

		public string Content
		{
			set
			{
				content = value;
			}
		}

		public CodeBlockType Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
			}
		}

		/// <summary>
		/// Replaces all tabs in content with 7 space characters. This can be
		/// desired for fonts where whitespace generated by the tab character
		/// is wider than desired.
		/// </summary>
		private string ContentWithTabToSpace
		{
			get
			{
				return content.Replace("\t", "       ");
			}
		}

		public string ContentUnformatted
		{
			get
			{
				return content;
			}
		}

		public CodeBlock() { }

		public CodeBlock(string content, CodeBlockType type)
		{
			this.type = type;
			this.content = content;
		}
		
		public bool IsLineBreak()
		{
			return type == CodeBlockType.LineBreak;
		}

		public bool IsEmptyOrWhitespace()
		{
			for(int n = content.Length - 1; n >= 0; n--)
			{
				if(!char.IsWhiteSpace(content[n]))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsComment()
		{
			return type == CodeBlockType.CommentBlock || type == CodeBlockType.CommentLine;
		}

		public void ToString(ref StringBuilder sb, ITextSyntaxFormatter builder)
		{
			switch(type)
			{
				case CodeBlockType.PreprocessorDirective:
					sb.Append(InspectorUtility.Preferences.theme.SyntaxHighlight.PreprocessorDirectiveColorTag);
					sb.Append(ContentWithTabToSpace);
					sb.Append("</color>");
					return;
				case CodeBlockType.CommentLine:
				case CodeBlockType.CommentBlock:
					sb.Append(builder.CommentColorTag);
					sb.Append(ContentWithTabToSpace);
					sb.Append("</color>");
					return;
				case CodeBlockType.Number:
					sb.Append(builder.NumberColorTag);
					sb.Append(content);
					sb.Append("</color>");
					return;
				case CodeBlockType.Type:
					sb.Append(InspectorUtility.Preferences.theme.SyntaxHighlight.TypeColorTag);
					sb.Append(content);
					sb.Append("</color>");
					return;
				case CodeBlockType.String:
				case CodeBlockType.Char:
					sb.Append(builder.StringColorTag);
					sb.Append(ContentWithTabToSpace);
					sb.Append("</color>");
					return;
				case CodeBlockType.Keyword:
					sb.Append(builder.KeywordColorTag);
					sb.Append(content);
					sb.Append("</color>");
					return;
				case CodeBlockType.LineBreak:
				case CodeBlockType.Unformatted:
					sb.Append(content);
					return;
				default:
					sb.Append(ContentWithTabToSpace);
					return;
			}
		}
	}
}