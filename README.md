1.概要
 このシステムは自作の短歌、俳句をデータベースに管理するプログラムです。

 2.システム構成

 　フロント画面->Blazor
   データベース->SQLite
   データ層->EntityFrameWork

3,プロジェクト一覧
本体
 ①,ShortSong 短歌、俳句管理画面を持った表面層
 ②,FLayer    短歌俳句APIの入口である内膜層
 ③,Blayer    ビジネスロジック層、データ加工、手続きを担当する層
 ④,Dlayer    Entity FrameWorkを使ったデータ層、SQLiteへのアクセス機能
 ⑤,FrontUT   ビジネスロジック層に対する自動単体テストをする表面層
ツール
 ①gen/GenFront テスト仕様書を読み込んで、テスト仕様書に書いてあるデータがDBにある体にするコンソールアプリ
               (EntityFramework専用、SQLは発効しない)
 ①gen/GenBLayer　テスト仕様書を読み込むビジネスロジック層
