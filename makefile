build:
	xbuild NetBounce.sln /p:Configuration=Release

build-debug:
	xbuild NetBounce.sln /p:Configuration=Debug

deploy:
	cp -r lib $(SRV)/
	cp -r NetBounce/static/* $(SRV)/static/
	cp -r NetBounce/bin $(SRV)/
	cp -r NetBounce/web.config $(SRV)/
	cp NetBounce/Global.asax NetBounce/Global.asax.cs $(SRV)/

