import React from "react"
import Logo from "../Assets/Logo.png"
export const Footer = () => {
	return (
		<>
			<div className='max-w-full w-full py-8 flex items-center justify-between bg-[#2A2A2A]'>
				<div className='max-w-7xl mx-auto w-full flex items-center justify-between'>
					<img src={Logo} alt='Logo' />
					<div className='items-center flex gap-x-8'>
						<a href='' className='font-sm block hover:text-ourPink text-[#fff]'>
							Найти команду
						</a>
						<span className='w-1 h-6 bg-[#fff] ' />
						<a href='' className='font-sm block hover:text-ourPink text-[#fff]'>
							Найти участника
						</a>
					</div>
					<img src={Logo} alt='Logo' />
				</div>
			</div>
		</>
	)
}
