# KeyInputII 
Unityにてキーコンフィグできるキー入力

※Assets/Plugins下に置いてください


## キーコンフィグの定義データ KeyConfigDefineData.cs
scriptableObject
こちらでnameに対応したKeyCodeを設定します（複数設定可能）
```
KeyConfig/Create Define Asset
こちらのメニューで以下のパスに定義データを作成します
Assets/Plugins/KeyInputII/ResourcesフォルダにDefaultKeyConfig.assetとして作成

※このフォルダをデフォルトのパスとして定義しています。
```


## キー入力やロードなど KeyInput.cs
 
```
KeyInput.I.SetDefaultDefine()
これがデフォルトのパスにある定義データを読み込みます。 
Assets/Plugins/KeyInputII/Resourcesフォルダにあるデータ
```

もし別のパスにある場合は読み込んだあと
```
KeyInput.I.SetDefine(KeyConfigDefineData data)
こちらで定義データをセットします。
```

変更されているキーコンフィグデータ KeyConfigSaveData.cs 
こちらをJsonなりで保存して、定義データを読み込んだあとに 
```
KeyInput.I.SetKeyConfigData(KeyConfigSaveData configSaveData)
これで変更済みキーコンフィグ設定をセットする
```

キー入力３種
----
```
KeyInput.I.IsKeyDown(string name, bool falseWhenAnyKeyPressed = false)
こちらでnameに対応したKeyCodeの押下した瞬間かどうかを返します。
falseWhenAnyKeyPressed : 対応したいずれのキーが押下した瞬間ではなく押している状態だったらfalseを返す
```

```
KeyInput.I.IsKeyPressed(string name, bool trueWhenAllPressed = false)
こちらでnameに対応したKeyCodeの押下しているか返します。
trueWhenAllPressed すべて押してないとtrueにならない
```

```
KeyInput.I.IsKeyUp(string name)
こちらでnameに対応したKeyCodeの入力がなくなった瞬間かどうか返します
```
----

## サンプルはExampleフォルダ下に
KeyConfigExample.sceneはキーコンフィグのテスト
KeyCheckExample.sceneは変更済みキー入力のテスト

シーンを切り替える場合はBuild SettingsのScenes In Buildに登録しておく必要があります

