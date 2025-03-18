using Avalonia.Controls.Templates;
using Avalonia.Controls;
using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPEN96.Avalonia.DataTemplates
{
    /// <summary>
    /// DictionaryDataTemplate
    /// https://github.com/AvaloniaUI/Avalonia.Samples/blob/main/src/Avalonia.Samples/DataTemplates/IDataTemplateSample/DataTemplates/ShapesTemplateSelector.cs
    /// </summary>
    public class DictionaryDataTemplate : IDataTemplate
    {
        /// <summary>
        /// 标记为[Content]在xaml中声明IDataTemplate，该元素存储IDataTemplate
        /// </summary>
        [Content]
        public Dictionary<string, IDataTemplate> AvailableTemplates { get; } = new Dictionary<string, IDataTemplate>();

        /// <summary>
        /// 构建DataTemplate
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Control Build(object? param)
        {
            var key = param?.ToString();
            if (key is null)
            {
                throw new ArgumentNullException(nameof(param));
            }
            // 查找并构建
            return AvailableTemplates[key].Build(param)!;
        }

        /// <summary>
        /// 检查我们是否可以接受提供的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Match(object? data)
        {
            var key = data?.ToString();

            return  // data is xxType && // 判断是否属于某类型        
                   !string.IsNullOrEmpty(key)
                   && AvailableTemplates.ContainsKey(key);
        }
    }
}
