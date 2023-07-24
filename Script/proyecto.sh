while [ true  ]
do

echo "Escriba options para ver la lista de opciones"

read input


case $input in 
	options)
		echo "Las opciones son: run, clean, report, slides, show_report, show_slides"
		;;
	run)
		cd ../
		dotnet watch run --project MoogleServer
		;;
	report)
		cd ../Informe/
		pdfLatex main.tex
		;;
	slides)
		cd ../Presentacion/
		pdfLatex main.tex
		;;
	show_report)
		if [ -f ../Informe/main.pdf ]
		then
			cd ../Informe/
			start main.pdf
		else
			cd ../Informe/
			pdfLatex main.tex
			cd ../Informe/
			start main.pdf
		fi
		;;	
	show_slides)
		if [ -f ../Presentacion/main.pdf ]
		then
			cd ../Presentacion/
			start main.pdf
		else
			cd ../Presentacion/
			pdfLatex main.tex
			cd ../Presentacion/
			start main.pdf
		fi
		;;
	clean) 
		rm -f ../Presentacion/*.aux
		rm -f ../Presentacion/*.log
		rm -f ../Presentacion/*.out
		rm -f ../Presentacion/*.nav
		rm -f ../Presentacion/*.toc
		rm -f ../Presentacion/*.snm
		rm -f ../Informe/*.aux
		rm -f ../Informe/*.log
	;;
	
	*)echo "Este comando no existe."
	;;	

esac
done