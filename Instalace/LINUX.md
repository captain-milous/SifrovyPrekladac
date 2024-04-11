# Instalace Šifrového Překladače na Linux

## 1. Nainstalujte [GIT](https://www.atlassian.com/git/tutorials/install-git)
```
sudo apt-get update 

sudo apt-get upgrade

sudo apt-get install git
```
## 2. Naklonujte si ropositoř
```
git clone https://github.com/captain-milous/SifrovyPrekladac.git
```
## 3. Nainstalujte [DOTNET](https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install)
```
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

chmod +x ./dotnet-install.sh

./dotnet-install.sh --channel 7.0

export DOTNET_ROOT=$(pwd)/.dotnet

export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools

export PATH="$PATH:$HOME/.dotnet"
```

## 4. Založte složku pro ukládání souborů
```
cd SifrovyPrekladac/Sifrovy\ Prekladac/bin/Debug/net7.0/

sudo mkdir Preklad_Sifer

sudo chmod 777 Preklad_Sifer
```
## 5. Spusťte aplikaci
```
dontnet SifrovyPrekladac.dll
```

# Spuštění již nainstalované aplikace po restartu zařízení
```
export PATH="$PATH:$HOME/.dotnet"

cd SifrovyPrekladac/Sifrovy\ Prekladac/bin/Debug/net7.0/

dontnet SifrovyPrekladac.dll
```