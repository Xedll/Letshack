import React, { useEffect, useState } from "react"
const isInArray = (item, array2) => {
	let flag = false
	for (let element of array2) {
		if (item == element.title) {
			flag = true
			break
		}
	}
	return flag
}
const indexInArray = (item, array2) => {
	let i = 0
	for (let element of array2) {
		if (item == element.title) {
			return i
		}
		i++
	}
	return -1
}
export const Filter = ({ color, data, handlefunc }) => {
	const [isSelecting, setIsSelecting] = useState(false)
	const [selected, setSelected] = useState([])
	const [numerus, setNumerus] = useState(0)
	useEffect(() => {}, [numerus])
	return (
		<div className='relative'>
			<div
				className={`${color == "pink" ? "bg-filter" : "bg-filter2"} w-8 h-8 cursor-pointer bg-center bg-no-repeat`}
				onClick={() => {
					setIsSelecting(!isSelecting)
				}}
			/>
			<div
				className={`${
					isSelecting ? "absolute" : "hidden"
				} top-0 left-full border-2 border-solid border-ourGrey rounded-xl bg-[#fff] p-4 gap-y-4 flex flex-col max-h-60 overflow-auto`}
			>
				{data.map((item, index) => {
					return (
						<>
							<p
								key={index}
								className={`font-sm w-full text-center cursor-pointer select-none`}
								onClick={() => {
									handlefunc(item)
									if (isInArray(item.title, selected)) {
										if (selected.length == 1) {
											setSelected([])
										} else {
											let test = selected
											test.splice(indexInArray(item.title, selected), 1)
											setSelected(test)
										}
									} else {
										setSelected([...selected, item])
									}
									setNumerus(Math.random())
								}}
							>
								{item.title} {isInArray(item.title, selected) ? String.fromCharCode(10003) : ""}
							</p>
							{index != data.length - 1 && <div key={`-${index}`} className='w-full h-1 bg-[#1D1F241A] ' />}
						</>
					)
				})}
			</div>
		</div>
	)
}
