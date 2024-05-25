import React from "react"
import Logo from "../Assets/Logo.png"
import Profile from "../Assets/Profile.png"
export const Header = () => {
	return (
		<div className='w-full py-8 flex items-center justify-between max-w-7xl mx-auto '>
			<img src={Logo} alt='Logo' />
			<div className='items-center flex gap-x-8'>
				<a href='' className='font-sm block hover:text-pink'>
					Найти команду
				</a>
				<span className='w-1 h-6 bg-[#1D1F2426] ' />
				<a href='' className='font-sm block hover:text-pink'>
					Найти участника
				</a>
			</div>
			<a href=''>
				<img src={Profile} alt='' />
			</a>
		</div>
	)
}
