// 代码生成时间: 2025-10-05 17:41:47
using System;
using System.Collections.Generic;

namespace TabSwitcherApplication
{
    /// <summary>
    /// Represents a tab switcher with methods to add, remove, and switch tabs.
    /// </summary>
    public class TabSwitcher
    {
        private Dictionary<string, ITab> tabs = new Dictionary<string, ITab>();
        private string currentTab;

        /// <summary>
        /// Initializes a new instance of the TabSwitcher class.
        /// </summary>
        public TabSwitcher()
        {
        }

        /// <summary>
        /// Adds a new tab to the switcher.
        /// </summary>
        /// <param name="tabName">The name of the tab.</param>
        /// <param name="tab">The tab instance.</param>
        /// <exception cref="ArgumentException">Thrown if a tab with the same name already exists.</exception>
        public void AddTab(string tabName, ITab tab)
        {
            if (tabs.ContainsKey(tabName))
            {
                throw new ArgumentException("You cannot have two tabs with the same name.");
            }

            tabs.Add(tabName, tab);
            if (tabs.Count == 1)
            {
                // If this is the first tab, set it as the current tab
                currentTab = tabName;
            }
        }

        /// <summary>
        /// Removes a tab from the switcher.
        /// </summary>
        /// <param name="tabName">The name of the tab to remove.</param>
        /// <returns>True if the tab was successfully removed, otherwise false.</returns>
        public bool RemoveTab(string tabName)
        {
            if (tabs.ContainsKey(tabName))
            {
                if (tabName == currentTab)
                {
                    currentTab = null;
                }
                return tabs.Remove(tabName);
            }
            return false;
        }

        /// <summary>
        /// Switches to the specified tab.
        /// </summary>
        /// <param name="tabName">The name of the tab to switch to.</param>
        /// <returns>True if the switch was successful, otherwise false.</returns>
        public bool SwitchTab(string tabName)
        {
            if (tabs.ContainsKey(tabName))
            {
                currentTab = tabName;
                tabs[currentTab].OnSelected();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the current tab name.
        /// </summary>
        public string CurrentTabName
        {
            get { return currentTab; }
        }

        /// <summary>
        /// Interface for a tab.
        /// </summary>
        public interface ITab
        {
            void OnSelected();
        }
    }

    /// <summary>
    /// Example implementation of a tab.
    /// </summary>
    public class ExampleTab : TabSwitcher.ITab
    {
        public void OnSelected()
        {
            Console.WriteLine("Example tab selected.");
        }
    }
}
