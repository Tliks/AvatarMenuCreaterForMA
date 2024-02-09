# AvatarMenuCreatorForMA

AvatarMenuCreator for Modular Avatar

## 概要

Modular Avatarでアバターのメニューを構成出来るようにする補助ツールです。

アバターのメニュー1項目をModular Avatarの1コンポーネントまたは1プレハブとして作成します。

・オブジェクト・BlendShape・シェーダーパラメーターのトグル制御（BoolでのToggle）
・オブジェクト・BlendShape・シェーダーパラメーター・マテリアルの選択制御（Intでの複数Toggle）
・BlendShape・シェーダーパラメーターの無段階調整（FloatのRadial Puppet）

等が可能です。

NDMF（Modular Avatar 1.8.0以降）のコンポーネントによる非破壊操作に対応していますが、Modular Avatar 1.7.7以前のバージョンでも動作します（この場合プレハブ生成機能のみ）。

## インストール

### VCCによる方法

1. https://vpm.narazaka.net/ から「Add to VCC」ボタンを押してリポジトリをVCCにインストールします。
2. VCCでSettings→Packages→Installed Repositoriesの一覧中で「Narazaka VPM Listing」にチェックが付いていることを確認します。
3. アバタープロジェクトの「Manage Project」から「AvatarMenuCreatorForMA」をインストールします。

### unitypackageによる方法

1. Modular Avatar https://modular-avatar.nadena.dev/ をインストールします。
2. [Releaseページ](https://github.com/Narazaka/AvatarMenuCreaterForMA/releases/latest) から net.narazaka.vrchat.avatar-menu-creater-for-ma-\*.\*.\***-novcc**.zip をダウンロード＆解凍し、unitypackageをアバタープロジェクトにインストールします。

## 使い方

1. 「Tools」→「Modular Avatar」→「AvatarMenuCreator for Modular Avatar」をクリックし、ツールを立ち上げます。

2. アバターをツールに設定し、アバター以下の制御したいオブジェクトを選択した状態でツールで処理を設定します。

3. 「Create!」ボタンを押して保存名を選択すれば、コンポーネントまたはModular AvatarのPrefabが出来上がります。

4. コンポーネントはアバターの中に生成されているためそのままで動作します。保存されたPrefabはアバターの中（直下でなくても良い）に置けば、Modular Avatarによってメニューが統合されます。

## 更新履歴

- 1.11.0-rc.2
  - AvatarParametersDriver連携をパラメーター名別指定に対応
- 1.11.0-rc.1
  - パラメーター名を別指定可能に
  - 内部値を指定可能に
- 1.11.0-rc.0
  - 各項目にオブジェクトの参照を出すように
  - コンポーネント設定に含まれる存在しないパスを表示するように
- 1.11.0-beta.4
  - マテリアル変更がSkinnedMeshRendererにしか適用されなかった問題を修正
- 1.11.0-beta.3
  - 想定外エラーを低減
- 1.11.0-beta.2
  - ON/OFFメニューでGameObject設定せずに「徐々に変化」を設定し、変化待機が0%でないか変化時間が100%でない場合、変化時間が正しくならなかった問題を修正
  - ON/OFFメニューの「徐々に変化」で線形に値が推移するように
- 1.11.0-beta.1
  - アセットからコンポーネントの復元をサポート
- 1.10.0
  - 複数メニュー一括生成をサポート（ON/OFF・無段階調整メニューにおいて/「コンポーネントを保持」の場合）
  - 1.7.0以降「同パラメーターや同マテリアルスロットを一括設定」がONなのにそう動作しない場合があったのを修正
- 1.9.2
  - AvatarParametersDriver 2.x系に対応
- 1.9.1
  - 互換性のない上限バージョンをインストールしないように修正
- 1.9.0
  - コンポーネントでMenuInstallerを削除するとMenuItemとして振る舞うように
- 1.8.1
  - Avatar Optimizerの警告を削減
- 1.8.0
  - AvatarParametersDriver連携を追加（コンポーネントに設定したパラメーターが出るようになります）
- 1.7.1
  - Meshが空のSkinnedMeshRendererでエラーになる問題を修正（AAO Merge SkinnedMesh 等でエラーにならなくなります）
- 1.7.0
  - 新機能
    - NDMFに対応
      - コンポーネントを追加することでアセット生成なしにメニューが生成されます。
      - NDMFは必須ではなく、従来通りModular Avatar 1.7.x 以前でも使えます。
    - NDMF環境でデフォルト保存モードを新しい「コンポーネントとして保持」に
    - パラメーター初期値・パラメーター保存・アイコンを最初から指定可能に
  - UI/UX改善
    - 事前生成時にも設定コンポーネントが保持されるように
      - 設定を調整しての再生成が可能に
    - プロパティの追加・一覧を便利に
      - 「+」ボタンから1項目ずつ追加できます
    - ON/OFF制御と追加削除も一括制御するように
    - prefab側で変更したMenuInstallerのインストール先が保持されるように
    - 選択式でマテリアルスロット1番目の選択肢にデフォルトのマテリアルをセットするように
    - Undoに対応
  - バグ修正
    - パッケージ名のスペルミスを修正（idは変更されません）
    - マテリアル一括設定がエラーになる場合がある問題を修正
    - 空マテリアルスロットでエラーになる問題を修正
- 1.7.0-rc.5
  - NDMF環境でデフォルト保存モードを「コンポーネントとして保持」に
- 1.7.0-rc.4
  - アセット事後生成に対応
  - コンポーネントをアバター外に出したときにエラーにならないように
- 1.7.0-rc.3
  - ON/OFF制御と追加削除も一括制御するように
- 1.7.0-rc.2
  - アイコン対応
  - 選択式でマテリアルスロット1番目の選択肢にデフォルトのマテリアルをセットするように
  - マテリアル一括設定がエラーになる場合がある問題を修正
  - 空マテリアルスロットでエラーになる問題を修正
- 1.7.0-rc.1
  - プロパティの追加・一覧を便利に
  - rc.0で選択式のGameObject制御の表示が不安定だったのを修正
- 1.7.0-rc.0
  - NDMFに対応
    - コンポーネントを追加することでアセット生成なしにメニューが生成されます。
    - NDMFは必須ではなく、Modular Avatar 1.7.x 以前でも使えます。
  - Undoに対応
  - 初期値とSavedを最初から指定可能に
  - prefab側で変更したMenuInstallerのインストール先などが保持されるように
  - パッケージ名のスペルミスを修正（idは変更されません）
- 1.6.2
  - Shader ParameterがSkinnedMeshRendererにしか適用されなかった問題を修正
- 1.6.1
  - 遷移時間を指定した場合デフォルトでない変数状態でアバター読み込みをした場合最初に遷移アニメーションが流れてしまう問題を修正
- 1.6.0
  - 無段階制御に無効領域を設定出来るように
- 1.5.1
  - 無段階調整のカーブが線形になるように修正
- 1.5.0
  - 選択肢式でGameObjectを複数選択肢で有効化可能に
- 1.4.0
  - 複数スロットの同一ソースマテリアルを統合的にいじれるUIを追加
- 1.3.2
  - asmdef修正
- 1.3.1
  - 保存時の場所を保持するように修正
  - まとめる形式で上書きした場合にメニューアセットが増殖しないように修正
  - キャンセルで空のオブジェクトが出来てしまう問題を修正
- 1.3.0
  - 選択肢メニュー機能を追加
  - 選択肢メニューでマテリアルを変更可能に
  - 同名パラメーター等を一括変更できるように
  - パフォーマンス改善
- 1.2.0
  - ON/OFFメニューで徐々に変化する機能
    - シェーダーパラメーター利用のフェード等が可能に
  - アセットをまとめられるように保存形式選択可能に
- 1.1.3
  - VCCでアバター用に表示されるように
- 1.1.2
  - VPM化
- 1.1.1
  - 1メッシュにマテリアルが2つ以上ある場合にエラーになる問題を修正
- 1.1.0
  - シェーダーパラメーターを設定する機能追加
- 1.0.0
  - リリース

## License

[Zlib License](LICENSE.txt)
