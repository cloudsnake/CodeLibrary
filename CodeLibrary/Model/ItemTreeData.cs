using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CodeLibrary.Model
{
    public class ItemTreeData // 自定义Item的树形结构
    {
        public int itemId { get; set; }      // ID
        public string titleName { get; set; } // 名称
        public int itemStep { get; set; }    // 所属的层级
        public int itemParent { get; set; }  // 父级的ID

        private ObservableCollection<ItemTreeData> _children = new ObservableCollection<ItemTreeData>();
        public ObservableCollection<ItemTreeData> Children
        {  // 树形结构的下一级列表
            get
            {
                return _children;
            }
        }
        public bool IsExpanded { get; set; } // 节点是否展开
        public bool IsSelected { get; set; } // 节点是否选中
    }

}
