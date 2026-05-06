# Epiano 簡易電子琴

<img width="748" height="217" alt="image" src="https://github.com/user-attachments/assets/a92de503-373d-443a-90fd-d470c5256f51" />


🎹 C# 數位電子琴 (Epiano Player)
這是一個基於 C# Windows Forms 開發的互動式模擬電子琴程式。

🌟 核心功能
八度音階彈奏：

調用 Windows 底層 kernel32.dll 的 Beep 函式發聲。

提供從 C4 (523Hz) 到 C5 (1046Hz) 的完整八度音階按鈕。

介面自適應縮放：

支援視窗自由拉伸，所有琴鍵按鈕會依比例自動調整大小與位置，確保佈局不跑版。

高效事件管理：

所有按鈕共用單一事件處理邏輯，透過 TabIndex 自動對應音頻，程式架構精簡。

📖 操作說明
彈奏：點擊介面上的按鈕 1 至 8，即可發出對應的 Do-Re-Mi 音效。

縮放：直接拖動視窗邊框，琴鍵會隨視窗大小同步放縮。
